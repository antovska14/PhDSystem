using NPOI.XWPF.UserModel;
using PhDSystem.Api.Adapters.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PhDSystem.Api.Adapters
{
    public class WordFileAdapter : IWordFileAdapter
    {
        private XWPFDocument _wordDocument;

        public WordFileAdapter(XWPFDocument wordDoument)
        {
            _wordDocument = wordDoument ?? throw new ArgumentNullException(nameof(wordDoument));
        }

        public Stream AsStream()
        {
            var str = new MemoryStream();
            _wordDocument.Write(str);
            return str;
        }

        public IList<XWPFParagraph> GetParagraphs()
        {
            return _wordDocument.Paragraphs;
        }

        public XWPFParagraph GetParagraph(int i)
        {
            return _wordDocument.Paragraphs[i];
        }
        
        public void CreateParagraph()
        {
            _wordDocument.CreateParagraph();
        }

        public void SetParagraph(XWPFParagraph paragraph, int i)
        {
            _wordDocument.SetParagraph(paragraph, i);
        }

        public void Write(Stream fileStream)
        {
            _wordDocument.Write(fileStream);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _wordDocument.Close();
            }
        }
    }
}
