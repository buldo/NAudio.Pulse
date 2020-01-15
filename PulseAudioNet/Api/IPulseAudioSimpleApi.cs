using System;

namespace PulseAudioNet.Api
{
    public interface IPulseAudioSimpleApi
    {
        IntPtr pa_simple_new(
            string server,
            string name,
            StreamDirection direction,
            string device,
            string streamName,
            ref SampleSpec spec,
            ref ChannelMap? channelMap,
            ref BufferAttr? bufferAttributes,
            out int error);

        void pa_simple_free(IntPtr s);

        /// <summary>
        /// Write some data to the server.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="data"></param>
        /// <param name="bytes"></param>
        /// <param name="error"></param>
        /// <returns>Zero on success, negative on error</returns>
        int pa_simple_write(IntPtr s, byte[] data, UIntPtr bytes, out int error);

        int pa_simple_drain(IntPtr s, out int error);

        int pa_simple_read(IntPtr s, byte[] data, UIntPtr bytes, out int error);

        ulong pa_simple_get_latency(IntPtr s, out int error);

        int pa_simple_flush(IntPtr s, out int error);
    }
}