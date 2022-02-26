using System;
using System.ComponentModel;
using System.Linq;
using Gtk;
using OpenTeleprompter.Data;
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
                            new Point(15, 0),
                            new Point(15, 20),
                            new Point(0, 20),
                        }
                    ),
                    new FontGlyphArea(
                        new[]
                        {
                            new Point(2, 2),
                            new Point(13, 2),
                            new Point(13, 18),
                            new Point(2, 18),
                        }
                    ),
                },
                15
            );
            var f = new Font(
                new []
                {
                    g
                },
                20
                );
            var fo1 = new TextStyleOptions(
                f,
                new Color(0, 0, 0)
                );
            var fo2 = new TextStyleOptions(
                f,
                new Color(255, 255, 255)
                );
            var t = new Text("aaaaaaaaaaaaaaaaaaaaaaaa\r\naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\naaaaaaaaaaaaa", new TextStyle(
                new[]
                {
                    new TextStyleInterval(0, fo1),
                    new TextStyleInterval(150, fo2),
                }
                ));
            var p = new Page(t, new PageStyle(new Color(0, 0, 0)));
            var r = new PageRenderer(p);
            c.Translate(50, 50);
            r.Render(c);
        };
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
