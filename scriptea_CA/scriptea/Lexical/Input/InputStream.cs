using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scriptea.Lexical.Input
{
    public class InputStream
    {
        private int _currentSymPos = 0;
        private string _buffer;
        private int _row;
        private int _column;
        private bool _ctrlEL;
        private bool _newToken;

        private int _prevRow;
        private int _prevColumn;
        public int Row { get { return _prevRow; } }
        public int Column { get { return _prevColumn; } }
        public int CurrentColumn { get { return _column; } }

        public bool CtrlNewToken
        {
            get { return _newToken; }
            set { _newToken = value; }
        }

        public char CurrentSymbol { get; set; }
        public InputStream(string pInput)
        {
            _row = 0;
            _column = 0;
            _buffer = pInput;
            ConsumeSymbol();
        }
        public void ConsumeSymbol()
        {
            if (CtrlNewToken)
            {
                _prevColumn = _column;
                CtrlNewToken = false;
            }
            _prevRow = _row;
            if(_currentSymPos < _buffer.Length)
            {
                CurrentSymbol = _buffer[_currentSymPos];
                _currentSymPos++;
                if (CurrentSymbol == '\n' || CurrentSymbol == '\r')
                {
                    if (!_ctrlEL)
                    {
                        _column = 0;
                        _row++;
                        _ctrlEL = true;
                    }
                }
                else
                {
                    _ctrlEL = false;
                    _column++;
                }
            }
            else
            {
                CurrentSymbol = (char)0;
            }
        }
    }
}
