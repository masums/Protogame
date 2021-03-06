﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Protoinject;

namespace Protogame
{
    /// <summary>
    /// A factory which instantiates objects for image processing.
    /// </summary>
    /// <module>Image Processing</module>
    public interface IImageProcessingFactory : IGenerateFactory
    {
        /// <summary>
        /// Creates an image source from a callback that returns an RGBA
        /// array and an image width.  This is the fastest kind of image
        /// source for image analysis.
        /// </summary>
        /// <param name="getRGBAArray">The callback which returns an array of RGBA values.</param>
        /// <param name="getWidth">The callback which returns the width of the image.</param>
        /// <returns>An image source which can be used in image analysis.</returns>
        ImageSourceFromRGBAArray CreateImageSource(Func<byte[]> getRGBAArray, Func<int> getWidth);

        /// <summary>
        /// Creates an image source from an in-memory texture.
        /// </summary>
        /// <param name="getTexture2D">The callback which returns the texture.</param>
        /// <returns>An image source which can be used in image analysis.</returns>
        ImageSourceFromTexture CreateImageSource(Func<Texture2D> getTexture2D);

        /// <summary>
        /// Creates an object which can be used for detecting colors in an
        /// image.  This functionality is useful for augmented reality, where you
        /// need to detect specific colored markers in an environment.
        /// </summary>
        /// <param name="source">The image source to detect color in.</param>
        /// <returns>The color detection object.</returns>
        IColorInImageDetection CreateColorInImageDetection(IImageSource source);

        /// <summary>
        /// Creates an object which can be used for converting detected colors
        /// in an image into a series of discrete points.
        /// </summary>
        /// <param name="colorInImageDetection">The color detection object.</param>
        /// <param name="selectedColorHandle">The color to detect points with.</param>
        /// <returns></returns>
        IPointInAnalysedImageDetection CreatePointInAnalysedImageDetection(
            IColorInImageDetection colorInImageDetection,
            ISelectedColorHandle selectedColorHandle);
    }
}
