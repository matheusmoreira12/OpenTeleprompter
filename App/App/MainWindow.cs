using System;
using System.ComponentModel;
using System.Linq;
using Gtk;
using OpenTeleprompter.Data;
using OpenTeleprompter.Rendering;

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
                            new Point(20, 0),
                            new Point(20, 20),
                            new Point(0, 20),
                        }
                    ),
                    new FontGlyphArea(
                        new[]
                        {
                            new Point(2, 2),
                            new Point(18, 2),
                            new Point(18, 18),
                            new Point(2, 18),
                        }
                    ),
                },
                new Size(20, 20)
            );
            var f = new Font(
                new []
                {
                    g
                }
                );
            var fo1 = new TextStyleOptions(
                false,
                false,
                false,
                true,
                false,
                new Color(0, 0, 0),
                new Color(255, 0, 0),
                f,
                20,
                0,
                10
                );
            var fo2 = new TextStyleOptions(
                false,
                false,
                false,
                false,
                false,
                new Color(0, 0, 0),
                new Color(0, 0, 0),
                f,
                20,
                0,
                10
                );
            var t = new Text("aaaaaaaaaaaaaaaaaaaaaaaa\n\raaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n\raaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n\raaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n\raaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n\raaaaaaaaaaaaa", new TextStyle(
                new[]
                {
                    new TextStyleInterval(0, fo1),
                    new TextStyleInterval(50, fo2),
                }
                ));
            var r = new TextRenderer(t);
            r.Render(c);
        };
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
