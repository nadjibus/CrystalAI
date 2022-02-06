using System;
using System.Collections.Generic;
using System.Text;

namespace Crystal
{
    public interface ITimeProvider
    {
        float TotalSeconds { get; }

        float TotalMilliseconds { get; }
    }
}
