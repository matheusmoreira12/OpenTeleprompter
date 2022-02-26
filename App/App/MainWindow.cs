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
                            new Point(8, 20),
                            new Point(16, 0)
                        }
                    ),
                    new FontGlyphArea(
                        new[]
                        {
                            new Point(2.5f, 0),
                            new Point(4, 4),
                            new Point(12, 4),
                            new Point(13.5f, 0)
                        }
                    ),
                    new FontGlyphArea(
                        new[]
                        {
                            new Point(5, 6),
                            new Point(8, 14.5f),
                            new Point(11, 6)
                        }
                    ),
                },
                16
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
            var t = new Text("a\r\naa\r\naaa\r\naaaa\r\naaaaa\r\n", new TextStyle(
                new[]
                {
                    new TextStyleInterval(0, 1, fo1),
                    new TextStyleInterval(2, 24, fo2),
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
