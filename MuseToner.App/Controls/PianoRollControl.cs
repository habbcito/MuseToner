using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using MuseToner.Core;
using System.Collections.Generic;

namespace MuseToner.App.Controls;

public class PianoRollControl : Control
{
    // List of the notes info.
    private List<NoteInfo> _notes = new List<NoteInfo>();

    // Brushes colors.
    private IBrush _inScaleBrush = new SolidColorBrush(Color.Parse("#FF3A2F55"));
    private IBrush _outScaleBrush = new SolidColorBrush(Color.Parse("#FF1C1C1C"));

    // Song info.
    private int _tonic = 0;
    private int[] _scale = new int[] { 0, 2, 4, 5, 7, 9, 11 };
    private double _durationSeconds = 30;



    public void SetNotes(List<NoteInfo> notes)
    {
        _notes = notes;

        // Total duration defines the width.
        double maxEnd = 0;
        foreach (NoteInfo n in _notes)
        {
            double end = n.StartSeconds + n.DurationSeconds;
            if (end > maxEnd) maxEnd = end;
        }
        _durationSeconds = maxEnd + 1;   // 1 sec of margin.

        InvalidateMeasure();   // Recalculates the WIDTH (MeasureOverride)
        InvalidateVisual();    // Redraw.
    }



    public void SetScale(int tonic, int[] scale)
    {
        _tonic = tonic;
        _scale = scale;
        InvalidateVisual();   // Redraw with new scale.
    }



    protected override Size MeasureOverride(Size availableSize)
    {
        double width = _durationSeconds * PianoRollLayout.PixelsPerSecond;
        return new Size(width, PianoRollLayout.TotalHeight());
    }



    public override void Render(DrawingContext context)
    {
        base.Render(context);
        
        for (int note = PianoRollLayout.MinNote; note <= PianoRollLayout.MaxNote; note++)
        {
            double y = PianoRollLayout.YValueOfNote(note);
            bool inScale = ScaleMath.NoteInScale(note, _tonic, _scale);

            IBrush brush;
            if (inScale)
                brush = _inScaleBrush;
            else
                brush = _outScaleBrush;

            context.FillRectangle(brush, new Rect(0, y, Bounds.Width, PianoRollLayout.RowHeight));
        }

        foreach (NoteInfo noteInfo in _notes)
        {
            // If the note is outside of the range , omit.
            if (noteInfo.NoteNumber < PianoRollLayout.MinNote || noteInfo.NoteNumber > PianoRollLayout.MaxNote)
                continue;

            double x      = noteInfo.StartSeconds * PianoRollLayout.PixelsPerSecond;
            double y      = PianoRollLayout.YValueOfNote(noteInfo.NoteNumber);
            double width  = noteInfo.DurationSeconds * PianoRollLayout.PixelsPerSecond;
            double height = PianoRollLayout.RowHeight;

            // Trying don't hide the shortest notes.
            if (width < 2)
                width = 2;

            IBrush brush;
            if (noteInfo.OutOfScale)
                brush = Brushes.Red;
            else
                brush = Brushes.LimeGreen;

            context.FillRectangle(brush, new Rect(x, y, width-1, height));
        }
    }
}