using System;
using System.ComponentModel;
using System.Linq;
using Gtk;
using OpenTeleprompter.Data;
using OpenTeleprompter.Data.Fonts;
using OpenTeleprompter.Rendering.Renderers;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();

        drawingarea1.ExposeEvent += (o, args) =>
        {
            var c = Gdk.CairoHelper.Create(drawingarea1.GdkWindow);
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
                new []
                {
                    g
                }, 40);

            var s = new TextStyleOptions(
                f,
                new Color(255, 255, 255));

            var t = new Text("a\r\naa\r\naaa\r\naaaa\r\naaaaa\r\n", new TextStyle(
                new[]
                {
                    new TextStyleInterval(0, 24, s),
                }));

            var p = new Page(t);

            var ps = new PageStyle(new Color(0, 0, 0));

            var d = new Document(new[] {
                    p
                },
                new Size(1080, 720),
                ps);

            int w, h;
            drawingarea1.GdkWindow.GetSize(out w, out h);

            var bc = d.PageStyle.BackgroundColor;
            c.SetSourceRGB(bc.R, bc.G, bc.B);
            c.Rectangle(0, 0, w, h);
            c.Fill();

            float pw = d.PageSize.Width,
                ph = d.PageSize.Height;
            float sc = Math.Min(w / pw, h / ph);

            float fpw = pw * sc,
                fph = ph * sc;

            float ox = (w - fpw) / 2,
                oy = (h - fph) / 2;

            c.Translate(ox, oy);
            c.Scale(sc, sc);

            //c.Translate(0, d.PageSize.Height / 2);

            //c.NewPath();
            //c.MoveTo(0, -20);
            //c.LineTo(34, 0);
            //c.LineTo(0, 20);
            //c.ClosePath();

            //c.Translate(44, 0);

            c.SetSourceRGB(255, 255, 255);
            c.Fill();

            var r = new DocumentRenderer(d);
            r.Render(c);
        };
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
