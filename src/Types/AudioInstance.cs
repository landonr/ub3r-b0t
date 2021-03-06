﻿namespace UB3RB0T
{
    using Discord.Audio;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    public class AudioInstance : IDisposable
    {
        internal bool isDisposed;
        internal bool isDisconnecting;

        internal readonly SemaphoreSlim streamLock = new SemaphoreSlim(1, 1);

        public Dictionary<ulong, AudioUserState> Users { get; } = new Dictionary<ulong, AudioUserState>();
        public ulong GuildId { get; set; }
        public IAudioClient AudioClient { get; set; }
        public Stream Stream { get; set; }

        public void Dispose() => Dispose(true);

        public void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                this.isDisposed = true;

                this.streamLock.Wait();

                try
                {
                    this.AudioClient.StopAsync().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    // TODO: proper logging
                    Console.WriteLine(ex);
                }

                this.Stream.Dispose();
                this.Stream = null;
                this.AudioClient.Dispose();
                this.streamLock.Release();
                this.streamLock.Dispose();
            }
        }
    }
}