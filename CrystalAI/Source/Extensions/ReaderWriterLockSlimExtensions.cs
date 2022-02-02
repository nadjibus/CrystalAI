// MIT License
// 
// Copyright (c) 2016-2017 Bismur Studios Ltd.
// Copyright (c) 2016-2017 Ioannis Giagkiozis
// 
// ReaderWriterLockSlimExtensions.cs is part of Crystal AI.
//  
// Crystal AI is free software: you can redistribute it and/or modify
// it under the terms of the MIT License


//  
// Crystal AI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

// 


using System;
using System.Threading;


namespace Crystal
{

    /// <summary>
    /// ReaderWriterLockSlim extensions.
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        /// <summary>
        /// Acquires a new read lock token.
        /// </summary>
        public static IDisposable Read(this ReaderWriterLockSlim @this)
        {
            return new ReadLockToken(@this);
        }

        /// <summary>
        /// Acquires a new write lock token.
        /// </summary>
        public static IDisposable Write(this ReaderWriterLockSlim @this)
        {
            return new WriteLockToken(@this);
        }

        sealed class ReadLockToken : IDisposable
        {
            ReaderWriterLockSlim _sync;

            public void Dispose()
            {
                if (_sync != null)
                {
                    _sync.ExitReadLock();
                    _sync = null;
                }
            }

            public ReadLockToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterReadLock();
            }
        }

        sealed class WriteLockToken : IDisposable
        {
            ReaderWriterLockSlim _sync;

            public void Dispose()
            {
                if (_sync != null)
                {
                    _sync.ExitWriteLock();
                    _sync = null;
                }
            }

            public WriteLockToken(ReaderWriterLockSlim sync)
            {
                _sync = sync;
                sync.EnterWriteLock();
            }
        }
    }

}