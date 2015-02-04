using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scriptea.Lexical.Input;

namespace scriptea.Lexical.States
{
    public interface IState
    {
        Token ProcessState(InputStream pInput, Lexeme pLexeme);
    }
}
