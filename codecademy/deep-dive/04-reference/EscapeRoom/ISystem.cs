using System;

namespace EscapeRoom
{
    interface ISystem {
        void Operate();
        string Status { get; set; }
    }
}