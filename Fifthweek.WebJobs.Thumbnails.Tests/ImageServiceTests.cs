﻿namespace Fifthweek.WebJobs.Thumbnails.Tests
{
    using System;
    using System.Drawing;
    using System.IO;

    using Fifthweek.WebJobs.Thumbnails.Shared;

    using ImageMagick;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ImageServiceTests
    {
        private ImageService target;

        private static readonly Color SideColor = Color.FromArgb(255, 0, 255, 0);

        private static readonly Color TopColor = Color.FromArgb(255, 0, 0, 255);

        [TestInitialize]
        public void TestInitialize()
        {
            this.target = new ImageService();
        }


        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndMaintainAspectRatio_Landscape()
        {
            var sampleImage = SampleImagesLoader.Instance.LargeLandscape;
            int desiredWidth = sampleImage.Height / 2;
            int desiredHeight = sampleImage.Height / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndMaintainAspectRatio_Portrait()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePortrait;
            int desiredWidth = sampleImage.Width / 2;
            int desiredHeight = sampleImage.Width / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndMaintainAspectRatio_Panorama()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePanorama;
            int desiredWidth = sampleImage.Height / 2;
            int desiredHeight = sampleImage.Height / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndMaintainAspectRatio_ColoredEdges()
        {
            var sampleImage = SampleImagesLoader.Instance.ColoredEdges;
            int desiredWidth = sampleImage.Height / 2;
            int desiredHeight = sampleImage.Height / 3;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(SideColor, this.GetLeft(image)),
                image => Assert.AreEqual(SideColor, this.GetRight(image)),
                image => Assert.AreEqual(TopColor, this.GetTop(image)),
                image => Assert.AreEqual(TopColor, this.GetBottom(image)));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldShrinkToTheSmallerSizeAndMaintainAspectRatio_Landscape()
        {
            var sampleImage = SampleImagesLoader.Instance.LargeLandscape;
            int desiredWidth = sampleImage.Width * 2;
            int desiredHeight = sampleImage.Height / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldShrinkToTheSmallerSizeAndMaintainAspectRatio_Portrait()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePortrait;
            int desiredWidth = sampleImage.Width / 2;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldShrinkToTheSmallerSizeAndMaintainAspectRatio_Panorama()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePanorama;
            int desiredWidth = sampleImage.Width / 2;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldShrinkToTheSmallerSizeAndMaintainAspectRatio_ColoredEdges()
        {
            var sampleImage = SampleImagesLoader.Instance.ColoredEdges;
            int desiredWidth = sampleImage.Width / 2;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(SideColor, this.GetLeft(image)),
                image => Assert.AreEqual(SideColor, this.GetRight(image)),
                image => Assert.AreEqual(TopColor, this.GetTop(image)),
                image => Assert.AreEqual(TopColor, this.GetBottom(image)));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldNotChangeTheImageSize_Landscape()
        {
            var sampleImage = SampleImagesLoader.Instance.LargeLandscape;
            int desiredWidth = sampleImage.Width * 2;
            int desiredHeight = sampleImage.Height * 3;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.AreEqual(sampleImage.Height, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldNotChangeTheImageSize_Portrait()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePortrait;
            int desiredWidth = sampleImage.Width;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.AreEqual(sampleImage.Height, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldNotChangeTheImageSize_Panorama()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePanorama;
            int desiredWidth = sampleImage.Width;
            int desiredHeight = sampleImage.Height;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.AreEqual(sampleImage.Height, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldNotChangeTheImageSize_ColoredEdges()
        {
            var sampleImage = SampleImagesLoader.Instance.ColoredEdges;
            int desiredWidth = sampleImage.Width * 3;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.AreEqual(sampleImage.Height, image.Height),
                image => Assert.AreEqual(SideColor, this.GetLeft(image)),
                image => Assert.AreEqual(SideColor, this.GetRight(image)),
                image => Assert.AreEqual(TopColor, this.GetTop(image)),
                image => Assert.AreEqual(TopColor, this.GetBottom(image)));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_WhenDarkenSpecified_ItShouldDarkenTheImage_ColoredEdges()
        {
            var sampleImage = SampleImagesLoader.Instance.ColoredEdges;
            int desiredWidth = sampleImage.Width;
            int desiredHeight = sampleImage.Height;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.MaintainAspectRatio,
                ProcessingBehaviour.Darken,
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.AreEqual(sampleImage.Height, image.Height),
                image => Assert.IsTrue(this.AreClose(this.Darken(SideColor), this.GetLeft(image))),
                image => Assert.IsTrue(this.AreClose(this.Darken(SideColor), this.GetRight(image))),
                image => Assert.IsTrue(this.AreClose(this.Darken(TopColor), this.GetTop(image))),
                image => Assert.IsTrue(this.AreClose(this.Darken(TopColor), this.GetBottom(image))));
        }

        private bool AreClose(Color a, Color b)
        {
            var r1 = (int)a.R;
            var r2 = (int)b.R;
            var g1 = (int)a.G;
            var g2 = (int)b.G;
            var b1 = (int)a.B;
            var b2 = (int)b.B;

            return Math.Abs(r1 - r2) < 2 && Math.Abs(g1 - g2) < 2 && Math.Abs(b1 - b2) < 2;
        }

        private Color Darken(Color input)
        {
            return Color.FromArgb(input.A, input.R / 2, input.G / 2, input.B / 2);
        }

        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndCropToAspectRatio_Landscape()
        {
            var sampleImage = SampleImagesLoader.Instance.LargeLandscape;
            int desiredWidth = sampleImage.Height / 2;
            int desiredHeight = sampleImage.Height / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndCropToAspectRatio_Portrait()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePortrait;
            int desiredWidth = sampleImage.Width / 2;
            int desiredHeight = sampleImage.Width / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndCropToAspectRatio_Panorama()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePanorama;
            int desiredWidth = sampleImage.Height / 2;
            int desiredHeight = sampleImage.Height / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionsAreSmaller_ItShouldShrinkAndCropToAspectRatio_ColoredEdges()
        {
            var sampleImage = SampleImagesLoader.Instance.ColoredEdges;
            int desiredWidth = sampleImage.Width / 8;
            int desiredHeight = sampleImage.Height / 4;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height),
                image => Assert.AreNotEqual(SideColor, this.GetLeft(image)),
                image => Assert.AreNotEqual(SideColor, this.GetRight(image)),
                image => Assert.AreEqual(TopColor, this.GetTop(image)),
                image => Assert.AreEqual(TopColor, this.GetBottom(image)));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldCropToAspectRatio_Landscape()
        {
            var sampleImage = SampleImagesLoader.Instance.LargeLandscape;
            int desiredWidth = sampleImage.Width * 2;
            int desiredHeight = sampleImage.Height / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.IsTrue(sampleImage.Height > image.Height));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldCropToAspectRatio_Portrait()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePortrait;
            int desiredWidth = sampleImage.Width / 2;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(sampleImage.Height, image.Height),
                image => Assert.IsTrue(sampleImage.Width > image.Width));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldCropToAspectRatio_Panorama()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePanorama;
            int desiredWidth = sampleImage.Width / 2;
            int desiredHeight = sampleImage.Height;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(desiredWidth, image.Width),
                image => Assert.AreEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(sampleImage.Height, image.Height),
                image => Assert.IsTrue(sampleImage.Width > image.Width));
        }

        [TestMethod]
        public void WhenOneDimensionIsSmaller_ItShouldCropToAspectRatio_ColoredEdges()
        {
            var sampleImage = SampleImagesLoader.Instance.ColoredEdges;
            int desiredWidth = sampleImage.Width * 2;
            int desiredHeight = sampleImage.Height / 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.IsTrue(sampleImage.Height > image.Height),
                image => Assert.AreEqual(SideColor, this.GetLeft(image)),
                image => Assert.AreEqual(SideColor, this.GetRight(image)),
                image => Assert.AreNotEqual(TopColor, this.GetTop(image)),
                image => Assert.AreNotEqual(TopColor, this.GetBottom(image)));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldCropToAspectRatio_Landscape()
        {
            var sampleImage = SampleImagesLoader.Instance.LargeLandscape;
            int desiredWidth = sampleImage.Width * 2;
            int desiredHeight = sampleImage.Height * 3;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(sampleImage.Height, image.Height),
                image => Assert.IsTrue(sampleImage.Width > image.Width));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldCropToAspectRatio_Portrait()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePortrait;
            int desiredWidth = sampleImage.Width;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(sampleImage.Height, image.Height),
                image => Assert.IsTrue(sampleImage.Width > image.Width));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldCropToAspectRatioPanorama()
        {
            var sampleImage = SampleImagesLoader.Instance.LargePanorama;
            int desiredWidth = sampleImage.Width;
            int desiredHeight = sampleImage.Height;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.AreEqual(sampleImage.Height, image.Height));
        }

        [TestMethod]
        public void WhenBothDimensionAreLargerOrSame_ItShouldCropToAspectRatio_ColoredEdges()
        {
            var sampleImage = SampleImagesLoader.Instance.ColoredEdges;
            int desiredWidth = sampleImage.Width * 4;
            int desiredHeight = sampleImage.Height * 2;

            this.PerformResizeTest(
                sampleImage,
                desiredWidth,
                desiredHeight,
                ResizeBehaviour.CropToAspectRatio,
                ProcessingBehaviour.None,
                image => Assert.AreNotEqual(desiredWidth, image.Width),
                image => Assert.AreNotEqual(desiredHeight, image.Height),
                image => Assert.AreEqual(sampleImage.Width, image.Width),
                image => Assert.IsTrue(sampleImage.Height > image.Height),
                image => Assert.AreEqual(SideColor, this.GetLeft(image)),
                image => Assert.AreEqual(SideColor, this.GetRight(image)),
                image => Assert.AreNotEqual(TopColor, this.GetTop(image)),
                image => Assert.AreNotEqual(TopColor, this.GetBottom(image)));
        }

        private static void SaveImage(MagickImage image, int width, int height, ResizeBehaviour resizeBehaviour)
        {
            image.Write(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    string.Format("{0}-{1}-{2}x{3}.jpeg", DateTime.UtcNow.Ticks, resizeBehaviour, width, height)));
        }

        private void PerformResizeTest(
            SampleImage sampleImage,
            int desiredWidth,
            int desiredHeight,
            ResizeBehaviour resizeBehaviour,
            ProcessingBehaviour processingBehaviour,
            params Action<Bitmap>[] asserts)
        {
            using (var inputStream = sampleImage.Open())
            using (var input = new MagickImage(inputStream))
            using (var outputStream = new MemoryStream())
            {
                this.target.Resize(input, outputStream, desiredWidth, desiredHeight, resizeBehaviour, processingBehaviour);
                ////SaveImage(input, desiredWidth, desiredHeight, resizeBehaviour);

                outputStream.Seek(0, SeekOrigin.Begin);
                var outputImage = new Bitmap(outputStream);

                foreach (var assert in asserts)
                {
                    assert(outputImage);
                }

                if (resizeBehaviour == ResizeBehaviour.MaintainAspectRatio)
                {
                    Assert.IsTrue(
                        this.AreClose(
                            sampleImage.Width / (double)sampleImage.Height,
                            outputImage.Width / (double)outputImage.Height));
                }
                else
                {
                    Assert.IsTrue(
                        this.AreClose(desiredWidth / (double)desiredHeight, outputImage.Width / (double)outputImage.Height));
                }
            }
        }

        private bool AreClose(double first, double second)
        {
            return Math.Abs(first - second) < 0.01;
        }

        private Color GetLeft(Bitmap image)
        {
            return image.GetPixel(0, image.Height / 2);
        }

        private Color GetRight(Bitmap image)
        {
            return image.GetPixel(image.Width - 1, image.Height / 2);
        }

        private Color GetTop(Bitmap image)
        {
            return image.GetPixel(image.Width / 2, 0);
        }

        private Color GetBottom(Bitmap image)
        {
            return image.GetPixel(image.Width / 2, image.Height - 1);
        }
    }
}