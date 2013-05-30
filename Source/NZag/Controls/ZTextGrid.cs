﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace NZag.Controls
{
    public class ZTextGrid : FrameworkElement
    {
        private readonly VisualCollection visuals;
        private readonly SortedList<Tuple<int, int>, VisualPair> visualPairs;

        private readonly Size fontCharSize;

        private int cursorX;
        private int cursorY;

        private Typeface typeface;
        private bool bold;
        private bool italic;
        private bool reverse;

        public ZTextGrid()
        {
            this.visuals = new VisualCollection(this);
            this.visualPairs = new SortedList<Tuple<int, int>, VisualPair>();

            var zero = new FormattedText(
                textToFormat: "0",
                culture: CultureInfo.InstalledUICulture,
                flowDirection: FlowDirection.LeftToRight,
                typeface: GetTypeface(),
                emSize: 16.0,
                foreground: Brushes.Black);

            this.fontCharSize = new Size(zero.Width, zero.Height);
        }

        private Typeface GetTypeface()
        {
            if (typeface == null)
            {
                var style = this.italic ? FontStyles.Italic : FontStyles.Normal;
                var weight = bold ? FontWeights.Bold : FontWeights.Normal;
                typeface = new Typeface(new FontFamily("Consolas"), style, weight, stretch: FontStretches.Normal);
            }

            return typeface;
        }

        public void Clear()
        {
            this.visuals.Clear();
            this.visualPairs.Clear();
            this.cursorX = 0;
            this.cursorY = 0;
        }

        public void PutChar(char ch)
        {
            if (ch == '\n')
            {
                this.cursorY += 1;
                this.cursorX = 0;
            }
            else
            {
                // First, see if we've already inserted something at this position.
                // If so, delete the old visuals.
                var cursorPos = Tuple.Create(this.cursorX, this.cursorY);
                if (this.visualPairs.ContainsKey(cursorPos))
                {
                    var visualPair = this.visualPairs[cursorPos];
                    this.visuals.Remove(visualPair.Background);
                    this.visuals.Remove(visualPair.Character);
                    this.visualPairs.Remove(cursorPos);
                }

                var backgroundVisual = new DrawingVisual();
                var backgroundContext = backgroundVisual.RenderOpen();

                var x = fontCharSize.Width * cursorX;
                var y = fontCharSize.Height * cursorY;

                Brush foreground, background;
                if (this.reverse)
                {
                    foreground = Brushes.White;
                    background = Brushes.Black;
                }
                else
                {
                    foreground = Brushes.Black;
                    background = Brushes.White;
                }

                var backgroundRect = new Rect(
                    Math.Floor(x),
                    Math.Floor(y),
                    Math.Ceiling(fontCharSize.Width*0.5),
                    Math.Ceiling(fontCharSize.Height));

                backgroundContext.DrawRectangle(background, null, backgroundRect);
                backgroundContext.Close();

                this.visuals.Insert(0, backgroundVisual);

                var textVisual = new DrawingVisual();
                var textContext = textVisual.RenderOpen();

                textContext.DrawText(
                    new FormattedText(
                        ch.ToString(CultureInfo.InvariantCulture),
                        CultureInfo.InstalledUICulture,
                        FlowDirection.LeftToRight,
                        GetTypeface(),
                        16.0,
                        foreground,
                        new NumberSubstitution(NumberCultureSource.User, CultureInfo.InstalledUICulture, NumberSubstitutionMethod.AsCulture),
                        TextFormattingMode.Display),
                    new Point(x, y));

                textContext.Close();

                this.visuals.Add(textVisual);

                var newVisualPair = new VisualPair(backgroundVisual, textVisual);
                this.visualPairs.Add(cursorPos, newVisualPair);

                this.cursorX += 1;
            }
        }

        public void SetBold(bool value)
        {
            this.bold = value;
            this.typeface = null;
        }

        public void SetItalic(bool value)
        {
            this.italic = value;
            this.typeface = null;
        }

        public void SetReverse(bool value)
        {
            this.reverse = value;
        }

        public int CursorX
        {
            get { return this.cursorX; }
        }

        public int CursorY
        {
            get { return this.cursorY; }
        }

        public void SetCursor(int x, int y)
        {
            this.cursorX = x;
            this.cursorY = y;
        }

        public void SetHeight(int lines)
        {
            for (int i = this.visualPairs.Count - 1; i >= 0; i--)
            {
                var cursorPos = this.visualPairs.Keys[i];
                var y = cursorPos.Item2;
                if (y > lines - 1)
                {
                    var visualPair = visualPairs[cursorPos];
                    this.visuals.Remove(visualPair.Background);
                    this.visuals.Remove(visualPair.Character);
                    this.visualPairs.Remove(cursorPos);
                }
            }
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.visuals[index];
        }

        protected override int VisualChildrenCount
        {
            get { return this.visuals.Count; }
        }
    }
}
