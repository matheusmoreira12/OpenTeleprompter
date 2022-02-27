using System;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using Gtk;
using OpenTeleprompter.Data;
using OpenTeleprompter.Data.Fonts;
using OpenTeleprompter.Rendering.Renderers;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        SetSizeRequest(Screen.Width, Screen.Height);

        var g = new FontGlyph(
                    'a',
                    new[] {
                    new FontGlyphArea(
                        new[]
                        {
                            new Point(0, 0),
                            new Point(16, 40),
                            new Point(32, 0)
                        }),
                    new FontGlyphArea(
                        new[]
                        {
                            new Point(5, 0),
                            new Point(8, 8),
                            new Point(24, 8),
                            new Point(27, 0)
                        }),
                    new FontGlyphArea(
                        new[]
                        {
                            new Point(10, 12),
                            new Point(16, 29),
                            new Point(22, 12)
                        }),
                }, 32);

        var f = new Font(
            new[]
            {
                    g
            }, 40);

        var s = new TextStyleOptions(
            f,
            new Color(255, 255, 255));

        var t1 = new Text("a\r\naa\r\naaa\r\naaaa\r\naaaaa\r\n", new TextStyle(
            new[]
            {
                    new TextStyleInterval(0, 24, s),
            }));

        var p1 = new Page(t1);

        var t2 = new Text("a\r\naa\r\naaa\r\naaaa\r\naaaaa\r\n", new TextStyle(
            new[]
            {
                    new TextStyleInterval(0, 24, s),
            }));

        var p2 = new Page(t2);

        var ps = new PageStyle(new Color(0, 0, 0));

        var d = new Document(new[] {
                    p1,
                    p2
                },
            new Size(1080, 720),
            ps);

        var dr = new DocumentReader();

        dr.State.OpenDocument = d;

        drawingarea1.ExposeEvent += (o, args) =>
        {
            int w, h;
            drawingarea1.GdkWindow.GetSize(out w, out h);

            var drr = new DocumentReaderRenderer(dr, new Size(w, h));

            var c = Gdk.CairoHelper.Create(drawingarea1.GdkWindow);

            drr.Render(c);
        };

        var ti = new Timer(1000 / 30);
        ti.Elapsed += (_, __) =>
        {
            drawingarea1.QueueDraw();
            Console.Write("tick");
        };
        ti.Enabled = true;

        float sy = 0;
        KeyPressEvent += (_, args) =>
        {
            switch (args.Event.Key)
            {
                case Gdk.Key.w:
                    sy += 40;
                    break;
                case Gdk.Key.s:
                    sy -= 40;
                    break;
            }
            dr.State.ScrollY = sy;
        };
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
