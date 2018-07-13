﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerVisionSample.helpers
{
    class Data
    {
        public const string VERSION = "2.0";
        public const string Settings_defaultMode = "Settings";
        public const string Settings_info = "Info";
        public const string Settings_clrAll = "Clear all";
        public const string Settings_handwrittenMode = "Handwritten mode";

        public const string Settings_info_Title = "Image Text Translator v" + VERSION;
        public const string Settings_info_Data = "Functionality: \n " +
            "- To start translating you may press cmare or gallery icon \n " +
            "- Before that you may choose translation destination language in right bottom corner \n" +
            "- 'Clear all' option removes all recognized data, and returns to default app state \n " +
            "- Handwritten Mode. IMPORTANT. For now allows to recognize only english text \n " +
            "- Awailable languages to detect: English, Czech, Danish, Dutch, Finnish, French, German, Greek, Hungarian, ChineseSimplified, ChineseTraditional, Italian, Japanese, Korean, Norwegian, Polish, Portuguese, Russian, Spanish, Swedish, Turkish, Romanian, Slovac, Serbian \n " +
            "- To enter ZOOM mode double tap on image after recognition is complete. To exit double tap again \n " +
            "- To copy recognized and translated text into clipboard just use long press(2 sec.) and popup will be triggered.";

        static public string[] settings = new String[]
        {
            Settings_defaultMode,
            Settings_info,
            Settings_clrAll,
            Settings_handwrittenMode
        };

        static public string[] destinationLanguages = new String[]
        {
            "Choose destination language",
            "English",
            "Ukrainian",
            "Russian",
            "French",
            "Polish",
            "Spanish",
            "German",
            "Italian",
            "Latvian",
            "Chinese",
            "Japanese",
            "Korean",
            "Portuguese",
            "Arabic",
            "Hindi",
            "Hebrew",
            "Swedish",
            "Danish",
            "Norwegian",
            "Finnish",
            "Georgian",
            "Turkish",
            "Czech",
            "Greek"
        };
        static public string[] hardwrittenLanguageSupports = new String[] 
        {
            "blab",
            "English",
            "English1"
        };
        static public string[] subscriptionKeys = new String[] 
        {
            "cf3b45431cc14c799696821dd9668990",
            "81e68751a466446c80076b8f82fd1adc"
        }; // 7c45fc48ba8f42e993a1cd173e1b59a7 
    }
}
