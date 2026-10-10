using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using MuseToner.Translations;

namespace MuseToner.App.Controls;

public class PianoKeysControl : Control
{
    protected override Size MeasureOverride(Size availableSize)
    {
        return new Size(PianoRollLayout.KeyWidth, PianoRollLayout.TotalHeight());
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        // BUCLE 1: las teclas (el que ya tienes)
        for (int note = PianoRollLayout.MinNote; note <= PianoRollLayout.MaxNote; note++)
        {
            double y = PianoRollLayout.YValueOfNote(note);

            IBrush brush;
            if (PianoRollLayout.IsBlackKey(note))
                brush = Brushes.Black;
            else
                brush = Brushes.White;

            context.FillRectangle(brush, new Rect(0, y, PianoRollLayout.KeyWidth, PianoRollLayout.RowHeight));
            context.DrawLine(new Pen(Brushes.Gray, 1), new Point(0, y), new Point(PianoRollLayout.KeyWidth, y));
        }

        // LOOP 2: The etiquettes of every C note.
        for (int note = PianoRollLayout.MinNote; note <= PianoRollLayout.MaxNote; note++)
        {
            if (note % 12 != 0) continue;

            double y = PianoRollLayout.YValueOfNote(note);
            int octave = (note / 12) - 1;

            FormattedText text = new FormattedText(
                Translator.NoteTranslateText(0) + octave,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                Typeface.Default,
                10,
                Brushes.Black);

            context.DrawText(text, new Point(2, y + (PianoRollLayout.RowHeight - text.Height) / 2));
        }
    }
}