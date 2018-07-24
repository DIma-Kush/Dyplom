// ��� : ������ "����������" Android
// ���������: ����� ������ (c) 2018
// �����������: �������� ������ ���������� � ���������� �� ���������� ���� � ������ ������

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ComputerVisionSample.Translator;
using Xamarin.Forms;
[assembly: Dependency(typeof(ComputerVisionSample.Droid.Android_Translator))]

namespace ComputerVisionSample.Droid
{
    public class Android_Translator : PCL_Translator
    {
        private const string googleUri = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";
        /// <summary>
        /// �������.
        /// </summary>
        public Exception Error
        {
            get;
            private set;
        }
        #region Public methods
        /// <summary>
        /// ��������� �������� �����
        /// </summary>
        /// <param name="sourceText">������� �����.</param>
        /// <param name="sourceLanguage">������ ����</param>
        /// <param name="targetLanguage">���� �����������</param>
        /// <returns>��������</returns>
        public  string Translate(string sourceText, string sourceLanguage, string targetLanguage)
        {
            // �����������
            this.Error = null;
            DateTime tmStart = DateTime.Now;
            string translation = string.Empty;
            try
            {
                // ����������� ��������
                string url = string.Format(googleUri, sourceLanguage, targetLanguage, HttpUtility.UrlEncode(sourceText));
                string outputFile = Path.GetTempFileName();
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    wc.DownloadFile(url, outputFile);
                }
                // �������� ���� ������ �� ������� �� � �������� ������
                if (File.Exists(outputFile))
                {
                    // �������� �������� ����
                    string text = File.ReadAllText(outputFile);
                    int index = text.IndexOf(string.Format(",,\"{0}\"", sourceLanguage));
                    // ����� ��������� ����� � ������� �� ������ ����� ����� : ������ - ������� ����� , ���� - ������������� �����
                    string[] phrases = text.Split(new[] { "\"," }, StringSplitOptions.RemoveEmptyEntries); 
                    for (int i = 0; i < phrases.Count(); i+=2)
                    {
                        if (i == phrases.Count() -1 ) break;
                        int startQuote2 = phrases[i].IndexOf('\"'); // ������� ������
                        if (startQuote2 != -1)
                        {
                            int endQuote2 = phrases[i].Length ; // ����� ������
                            if (endQuote2 != -1)
                            {
                                // �������� �� � ������ ����������
                                translation += phrases[i].Substring(startQuote2 + 1, endQuote2 - startQuote2 - 1); 
                            }
                        }
                    }
                    // �������� ������ ������� � ���������� ������
                    translation = translation.Trim();
                    translation = translation.Replace(" ?", "?");
                    translation = translation.Replace(" !", "!");
                    translation = translation.Replace(" ,", ",");
                    translation = translation.Replace(" .", ".");
                    translation = translation.Replace(" ;", ";");
                }
            }
            catch (Exception ex)
            {
                this.Error = ex;
                return null;
            }
            return translation;
        }
    }
}
#endregion
