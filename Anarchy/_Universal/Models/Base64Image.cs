﻿using System;
using System.Drawing;

namespace Discord
{
    public class Base64Image
    {
        public string ImageBase64 { get; private set; }

        private Image _image;
        public Image Image
        {
            get { return _image; }
            set
            {
                if (value == null)
                    ImageBase64 = null;
                else
                {
                    ImageBase64 = "data:image/png;base64," + 
                            Convert.ToBase64String((byte[])new ImageConverter().ConvertTo(value, typeof(byte[])));
                    _image = value;
                }
            }
        }
    }
}