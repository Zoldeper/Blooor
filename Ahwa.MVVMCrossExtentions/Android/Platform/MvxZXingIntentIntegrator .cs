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
using Android.Content.PM;
using ANet = Android.Net;
using Cirrious.MvvmCross.Platform.Diagnostics;

namespace Cirrious.MvvmCross.Android.Platform
{
    public class MvxZXingIntentIntegrator
    {
        public const int REQUEST_CODE = 0x0000c0de; // Only use bottom 16 bits
        private static String TAG = typeof(MvxZXingIntentIntegrator).Name;

        public const String DEFAULT_TITLE = "Install Barcode Scanner?";
        public const String DEFAULT_MESSAGE =
            "This application requires Barcode Scanner. Would you like to install it?";
        public const String DEFAULT_YES = "Yes";
        public const String DEFAULT_NO = "No";

        private const String BS_PACKAGE = "com.google.zxing.client.android";
        private const String BSPLUS_PACKAGE = "com.srowen.bs.android";

        // supported barcode formats
        public static List<String> PRODUCT_CODE_TYPES = new List<String>() { "UPC_A", "UPC_E", "EAN_8", "EAN_13", "RSS_14" };
        public static List<String> ONE_D_CODE_TYPES =
            new List<String>(){"UPC_A", "UPC_E", "EAN_8", "EAN_13", "CODE_39", "CODE_93", "CODE_128",
                   "ITF", "RSS_14", "RSS_EXPANDED"};
        public static List<String> QR_CODE_TYPES = new List<String>() { "QR_CODE" };
        public static List<String> DATA_MATRIX_TYPES = new List<String>() { "DATA_MATRIX" };

        public static List<String> ALL_CODE_TYPES = null;

        public static List<String> TARGET_BARCODE_SCANNER_ONLY = new List<String>() { BS_PACKAGE };
        public static List<String> TARGET_ALL_KNOWN = new List<String>(){
                  BS_PACKAGE, // Barcode Scanner
                  BSPLUS_PACKAGE, // Barcode Scanner+
                  BSPLUS_PACKAGE + ".simple" // Barcode Scanner+ Simple
                  // What else supports this intent?
          };

        private Activity activity;
        private Dictionary<String, Object> moreExtras = new Dictionary<string, object>();

        public String Title{get;set;}
        public String Message { get; set; }
        public String ButtonYes { get; set; }
        public String ButtonNo { get; set; }
        public List<String> TargetApplications { get; set; }
        
        public void SetTitleByID(int titleID)
        {
            Title = activity.GetString(titleID);
        }
        public void SetMessageByID(int messageID)
        {
            Message = activity.GetString(messageID);
        }
        public void SetButtonYesID(int buttonYes)
        {
            ButtonYes = activity.GetString(buttonYes);
        }
        public void SetButtonNoByID(int buttonNoID)
        {
            ButtonNo = activity.GetString(buttonNoID);
        }
        public void SetSingleTargetApplication(String targetApplication)
        {
            TargetApplications = new List<string>() { targetApplication };
        }

        public Dictionary<String, object> getMoreExtras()
        {
            return moreExtras;
        }

        private Action<int, Intent> _StartActivityForResult;

        public MvxZXingIntentIntegrator(Activity activity, Action<int, Intent> startActivityForResult)
        {
            this.activity = activity;
            Title = DEFAULT_TITLE;
            Message = DEFAULT_MESSAGE;
            ButtonYes = DEFAULT_YES;
            ButtonNo = DEFAULT_NO;
            TargetApplications = TARGET_ALL_KNOWN;
            _StartActivityForResult = startActivityForResult;
        }

        public void AddExtra(String key, Object value)
        {
            moreExtras.Add(key, value);
        }

        /**
       * Initiates a scan for all known barcode types.
       */
        public AlertDialog InitiateScan()
        {
            return InitiateScan(ALL_CODE_TYPES);
        }

        /**
         * Initiates a scan only for a certain set of barcode types, given as strings corresponding
         * to their names in ZXing's {@code BarcodeFormat} class like "UPC_A". You can supply constants
         * like {@link #PRODUCT_CODE_TYPES} for example.
         *
         * @return the {@link AlertDialog} that was shown to the user prompting them to download the app
         *   if a prompt was needed, or null otherwise
         */
        public AlertDialog InitiateScan(List<String> desiredBarcodeFormats)
        {
            Intent intentScan = new Intent(BS_PACKAGE + ".SCAN");
            intentScan.AddCategory(Intent.CategoryDefault);

            // check which types of codes to scan for
            if (desiredBarcodeFormats != null)
            {
                // set the desired barcode types
                StringBuilder joinedByComma = new StringBuilder();
                foreach (String format in desiredBarcodeFormats)
                {
                    if (joinedByComma.Length > 0)
                    {
                        joinedByComma.Append(',');
                    }
                    joinedByComma.Append(format);
                }
                intentScan.PutExtra("SCAN_FORMATS", joinedByComma.ToString());
            }

            String targetAppPackage = FindTargetAppPackage(intentScan);
            if (targetAppPackage == null)
            {
                return ShowDownloadDialog();
            }
            intentScan.SetPackage(targetAppPackage);
            intentScan.AddFlags(ActivityFlags.ClearTop);
            intentScan.AddFlags(ActivityFlags.ClearWhenTaskReset);
            AttachMoreExtras(intentScan);
            StartActivityForResult(intentScan, REQUEST_CODE);
            return null;
        }

        /**
         * Start an activity.<br>
         * This method is defined to allow different methods of activity starting for
         * newer versions of Android and for compatibility library.
         *
         * @param intent Intent to start.
         * @param code Request code for the activity
         * @see android.app.Activity#startActivityForResult(Intent, int)
         * @see android.app.Fragment#startActivityForResult(Intent, int)
         */
        protected void StartActivityForResult(Intent intent, int code)
        {
            if (_StartActivityForResult != null)
                _StartActivityForResult(code, intent);
            else
                activity.StartActivityForResult(intent, code);
        }

        private String FindTargetAppPackage(Intent intent)
        {
            PackageManager pm = activity.PackageManager;
            var availableApps = pm.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            if (availableApps != null)
            {
                foreach (ResolveInfo availableApp in availableApps)
                {
                    String packageName = availableApp.ActivityInfo.PackageName;
                    if (TargetApplications.Contains(packageName))
                    {
                        return packageName;
                    }
                }
            }
            return null;
        }

        private AlertDialog ShowDownloadDialog()
        {
            AlertDialog.Builder downloadDialog = new AlertDialog.Builder(activity);
            downloadDialog.SetTitle(Title);
            downloadDialog.SetMessage(Message);
            downloadDialog.SetPositiveButton(ButtonYes,
                (sender, args) =>
                {

                    var uri = ANet.Uri.Parse("market://details?id=" + BS_PACKAGE);
                    Intent intent = new Intent(Intent.ActionView, uri);
                    try
                    {
                        activity.StartActivity(intent);
                    }
                    catch (ActivityNotFoundException anfe)
                    {
                        // Hmm, market is not installed
                        MvxTrace.TaggedTrace(TAG, "Android Market is not installed; cannot install Barcode Scanner");
                    }
                });
            downloadDialog.SetNegativeButton(ButtonNo, (sender, args) => { });
            return downloadDialog.Show();
        }

        /**
         * <p>Call this from your {@link Activity}'s
         * {@link Activity#onActivityResult(int, int, Intent)} method.</p>
         *
         * @return null if the event handled here was not related to this class, or
         *  else an {@link IntentResult} containing the result of the scan. If the user cancelled scanning,
         *  the fields will be null.
         */
        public static MvxZXingIntentResult ParseActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            if (requestCode == REQUEST_CODE)
            {
                if (resultCode == Result.Ok)
                {
                    String contents = intent.GetStringExtra("SCAN_RESULT");
                    String formatName = intent.GetStringExtra("SCAN_RESULT_FORMAT");
                    byte[] rawBytes = intent.GetByteArrayExtra("SCAN_RESULT_BYTES");
                    int? intentOrientation = intent.GetIntExtra("SCAN_RESULT_ORIENTATION", int.MinValue);
                    int? orientation = intentOrientation == int.MinValue ? null : intentOrientation;
                    String errorCorrectionLevel = intent.GetStringExtra("SCAN_RESULT_ERROR_CORRECTION_LEVEL");
                    return new MvxZXingIntentResult(contents,
                                            formatName,
                                            rawBytes,
                                            orientation,
                                            errorCorrectionLevel);
                }
                return new MvxZXingIntentResult();
            }
            return null;
        }

        /**
         * Defaults to type "TEXT_TYPE".
         * @see #shareText(CharSequence, CharSequence)
         */
        public AlertDialog ShareText(string text)
        {
            return ShareText(text, "TEXT_TYPE");
        }

        /**
         * Shares the given text by encoding it as a barcode, such that another user can
         * scan the text off the screen of the device.
         *
         * @param text the text string to encode as a barcode
         * @param type type of data to encode. See {@code com.google.zxing.client.android.Contents.Type} constants.
         * @return the {@link AlertDialog} that was shown to the user prompting them to download the app
         *   if a prompt was needed, or null otherwise
         */
        public AlertDialog ShareText(string text, string type)
        {
            Intent intent = new Intent();
            intent.AddCategory(Intent.CategoryDefault);
            intent.SetAction(BS_PACKAGE + ".ENCODE");
            intent.PutExtra("ENCODE_TYPE", type);
            intent.PutExtra("ENCODE_DATA", text);
            String targetAppPackage = FindTargetAppPackage(intent);
            if (targetAppPackage == null)
            {
                return ShowDownloadDialog();
            }
            intent.SetPackage(targetAppPackage);
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.AddFlags(ActivityFlags.ClearWhenTaskReset);
            AttachMoreExtras(intent);
            activity.StartActivity(intent);
            return null;
        }

        private void AttachMoreExtras(Intent intent)
        {
            foreach (var entry in moreExtras)
            {
                String key = entry.Key;
                Object value = entry.Value;
                // Kind of hacky
                if (value is int)
                {
                    intent.PutExtra(key, (int)value);
                }
                else if (value is long)
                {
                    intent.PutExtra(key, (long)value);
                }
                else if (value is bool)
                {
                    intent.PutExtra(key, (bool)value);
                }
                else if (value is double)
                {
                    intent.PutExtra(key, (Double)value);
                }
                else if (value is float)
                {
                    intent.PutExtra(key, (float)value);
                }
                else if (value is Bundle)
                {
                    intent.PutExtra(key, (Bundle)value);
                }
                else
                {
                    intent.PutExtra(key, value.ToString());
                }
            }
        }
    }
}