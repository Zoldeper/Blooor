/*
 * Copyright 2009 ZXing authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Cirrious.MvvmCross.Android.Platform
{
    public class MvxZXingIntentResult
    {
        /**
         * @return raw content of barcode
         */
        public String Contents { get; private set; }

        /**
         * @return name of format, like "QR_CODE", "UPC_A". See {@code BarcodeFormat} for more format names.
         */
        public String FormatName { get; private set; }

        /**
         * @return raw bytes of the barcode content, if applicable, or null otherwise
         */
        public byte[] RawBytes { get; private set; }

        /**
         * @return rotation of the image, in degrees, which resulted in a successful scan. May be null.
         */
        public int? Orientation { get; private set; }

        /**
         * @return name of the error correction level used in the barcode, if applicable
         */
        public String ErrorCorrectionLevel { get; private set; }

        public MvxZXingIntentResult()
            : this(null, null, null, null, null)
        {

        }

        public MvxZXingIntentResult(String contents,
                     String formatName,
                     byte[] rawBytes,
                     int? orientation,
                     String errorCorrectionLevel)
        {
            this.Contents = contents;
            this.FormatName = formatName;
            this.RawBytes = rawBytes;
            this.Orientation = orientation;
            this.ErrorCorrectionLevel = errorCorrectionLevel;
        }

        public override string ToString()
        {
            StringBuilder dialogText = new StringBuilder();
            dialogText.Append("Format: ").Append(FormatName).Append('\n');
            dialogText.Append("Contents: ").Append(Contents).Append('\n');
            
            int rawBytesLength = RawBytes == null ? 0 : RawBytes.Length;
            dialogText.Append("Raw bytes: (").Append(rawBytesLength).Append(" bytes)\n");
            
            dialogText.Append("Orientation: ").Append(Orientation).Append('\n');
            dialogText.Append("EC level: ").Append(ErrorCorrectionLevel).Append('\n');
            return dialogText.ToString();
        }
    }
}