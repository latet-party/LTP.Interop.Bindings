#region License
/*
    Opus Codec

    Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

    - Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

    - Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

    - Neither the name of Internet Society, IETF or IETF Trust, nor the names of specific contributors, may be used to endorse or promote products derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

#region Using statements
using System;

using LTP.Interop.InteropServices;
#endregion

[Library( "opus" )]
public static unsafe class Opus
{
    #region Fields / Properties
    private static IntPtr _handle;
    #endregion

    #region Constants
    public const int OPUS_OK = 0;
    public const int OPUS_BAD_ARG = -1;
    public const int OPUS_BUFFER_TOO_SMALL = -2;
    public const int OPUS_INTERNAL_ERROR = -3;
    public const int OPUS_INVALID_PACKET = -4;
    public const int OPUS_UNIMPLEMENTED = -5;
    public const int OPUS_INVALID_STATE = -6;
    public const int OPUS_ALLOC_FAIL = -7;
    public const int OPUS_SET_APPLICATION_REQUEST = 4000;
    public const int OPUS_GET_APPLICATION_REQUEST = 4001;
    public const int OPUS_SET_BITRATE_REQUEST = 4002;
    public const int OPUS_GET_BITRATE_REQUEST = 4003;
    public const int OPUS_SET_MAX_BANDWIDTH_REQUEST = 4004;
    public const int OPUS_GET_MAX_BANDWIDTH_REQUEST = 4005;
    public const int OPUS_SET_VBR_REQUEST = 4006;
    public const int OPUS_GET_VBR_REQUEST = 4007;
    public const int OPUS_SET_BANDWIDTH_REQUEST = 4008;
    public const int OPUS_GET_BANDWIDTH_REQUEST = 4009;
    public const int OPUS_SET_COMPLEXITY_REQUEST = 4010;
    public const int OPUS_GET_COMPLEXITY_REQUEST = 4011;
    public const int OPUS_SET_INBAND_FEC_REQUEST = 4012;
    public const int OPUS_GET_INBAND_FEC_REQUEST = 4013;
    public const int OPUS_SET_PACKET_LOSS_PERC_REQUEST = 4014;
    public const int OPUS_GET_PACKET_LOSS_PERC_REQUEST = 4015;
    public const int OPUS_SET_DTX_REQUEST = 4016;
    public const int OPUS_GET_DTX_REQUEST = 4017;
    public const int OPUS_SET_VBR_CONSTRAINT_REQUEST = 4020;
    public const int OPUS_GET_VBR_CONSTRAINT_REQUEST = 4021;
    public const int OPUS_SET_FORCE_CHANNELS_REQUEST = 4022;
    public const int OPUS_GET_FORCE_CHANNELS_REQUEST = 4023;
    public const int OPUS_SET_SIGNAL_REQUEST = 4024;
    public const int OPUS_GET_SIGNAL_REQUEST = 4025;
    public const int OPUS_GET_LOOKAHEAD_REQUEST = 4027;
    public const int OPUS_GET_SAMPLE_RATE_REQUEST = 4029;
    public const int OPUS_GET_FINAL_RANGE_REQUEST = 4031;
    public const int OPUS_GET_PITCH_REQUEST = 4033;
    public const int OPUS_SET_GAIN_REQUEST = 4034;
    public const int OPUS_GET_GAIN_REQUEST = 4045;
    public const int OPUS_SET_LSB_DEPTH_REQUEST = 4036;
    public const int OPUS_GET_LSB_DEPTH_REQUEST = 4037;
    public const int OPUS_GET_LAST_PACKET_DURATION_REQUEST = 4039;
    public const int OPUS_SET_EXPERT_FRAME_DURATION_REQUEST = 4040;
    public const int OPUS_GET_EXPERT_FRAME_DURATION_REQUEST = 4041;
    public const int OPUS_SET_PREDICTION_DISABLED_REQUEST = 4042;
    public const int OPUS_GET_PREDICTION_DISABLED_REQUEST = 4043;
    public const int OPUS_SET_PHASE_INVERSION_DISABLED_REQUEST = 4046;
    public const int OPUS_GET_PHASE_INVERSION_DISABLED_REQUEST = 4047;
    public const int OPUS_AUTO = -1000;
    public const int OPUS_BITRATE_MAX = -1;
    public const int OPUS_APPLICATION_VOIP = 2048;
    public const int OPUS_APPLICATION_AUDIO = 2049;
    public const int OPUS_APPLICATION_RESTRICTED_LOWDELAY = 2051;
    public const int OPUS_SIGNAL_VOICE = 3001;
    public const int OPUS_SIGNAL_MUSIC = 3002;
    public const int OPUS_BANDWIDTH_NARROWBAND = 1101;
    public const int OPUS_BANDWIDTH_MEDIUMBAND = 1102;
    public const int OPUS_BANDWIDTH_WIDEBAND = 1103;
    public const int OPUS_BANDWIDTH_SUPERWIDEBAND = 1104;
    public const int OPUS_BANDWIDTH_FULLBAND = 1105;
    public const int OPUS_FRAMESIZE_ARG = 5000;
    public const int OPUS_FRAMESIZE_2_5_MS = 5001;
    public const int OPUS_FRAMESIZE_5_MS = 5002;
    public const int OPUS_FRAMESIZE_10_MS = 5003;
    public const int OPUS_FRAMESIZE_20_MS = 5004;
    public const int OPUS_FRAMESIZE_40_MS = 5005;
    public const int OPUS_FRAMESIZE_60_MS = 5006;
    public const int OPUS_FRAMESIZE_80_MS = 5007;
    public const int OPUS_FRAMESIZE_100_MS = 5008;
    public const int OPUS_FRAMESIZE_120_MS = 5009;
    #endregion

    #region Delegates
    public delegate void* PFNOPUS_STRERRORPROC( int error );
    public delegate void* PFNOPUS_GET_VERSION_STRINGPROC();
    public delegate int PFNOPUS_ENCODER_GET_SIZEPROC( int channels );
    public delegate void* PFNOPUS_ENCODER_CREATEPROC( int Fs, int channels, int application, out int error );
    public delegate int PFNOPUS_ENCODER_INITPROC( void* st, int Fs, int channels, int application );
    public delegate int PFNOPUS_ENCODEPROC( void* st, short* pcm, int frame_size, void* data, int max_data_bytes );
    public delegate int PFNOPUS_ENCODE_FLOATPROC( void* st, float* pcm, int frame_size, void* data, int max_data_bytes );
    public delegate void PFNOPUS_ENCODER_DESTROYPROC( void* st );
    public delegate int PFNOPUS_DECODER_GET_SIZEPROC( int channels );
    public delegate void* PFNOPUS_DECODER_CREATEPROC( int Fs, int channels, out int error );
    public delegate int PFNOPUS_DECODER_INITPROC( void* st, int Fs, int channels );
    public delegate int PFNOPUS_DECODEPROC( void* st, byte* data, int len, short* pcm, int frame_size, int decode_fec );
    public delegate int PFNOPUS_DECODE_FLOATPROC( void* st, byte* data, int len, float* pcm, int frame_size, int decode_fec );
    public delegate void PFNOPUS_DECODER_DESTROYPROC( void* st );
    public delegate int PFNOPUS_PACKET_GET_BANDWIDTHPROC( byte* data );
    public delegate int PFNOPUS_PACKET_GET_SAMPLES_PER_FRAMEPROC( byte* data, int Fs );
    public delegate int PFNOPUS_PACKET_GET_NB_CHANNELSPROC( byte* data );
    public delegate int PFNOPUS_PACKET_GET_NB_FRAMESPROC( byte* packet, int len );
    public delegate int PFNOPUS_PACKET_GET_NB_SAMPLESPROC( byte* packet, int len, int Fs );
    public delegate int PFNOPUS_DECODER_GET_NB_SAMPLESPROC( void* dec, byte* packet, int len );
    public delegate void PFNOPUS_PCM_SOFT_CLIPPROC( float* pcm, int frame_size, int channels, float* softclip_mem );
    public delegate int PFNOPUS_REPACKETIZER_GET_SIZEPROC();
    public delegate void* PFNOPUS_REPACKETIZER_INITPROC( void* rp );
    public delegate void* PFNOPUS_REPACKETIZER_CREATEPROC();
    public delegate void PFNOPUS_REPACKETIZER_DESTROYPROC( void* rp );
    public delegate int PFNOPUS_REPACKETIZER_CATPROC( void* rp, byte* data, int len );
    public delegate int PFNOPUS_REPACKETIZER_OUT_RANGEPROC( void* rp, int begin, int end, void* data, int maxlen );
    public delegate int PFNOPUS_REPACKETIZER_GET_NB_FRAMESPROC( void* rp );
    public delegate int PFNOPUS_REPACKETIZER_OUTPROC( void* rp, void* data, int maxlen );
    public delegate int PFNOPUS_PACKET_PADPROC( void* data, int len, int new_len );
    public delegate int PFNOPUS_PACKET_UNPADPROC( void* data, int len );
    public delegate int PFNOPUS_MULTISTREAM_PACKET_PADPROC( void* data, int len, int new_len, int nb_streams );
    public delegate int PFNOPUS_MULTISTREAM_PACKET_UNPADPROC( void* data, int len, int nb_streams );
    public delegate int PFNOPUS_ENCODER_CTLPROC( void* st, int request, object value );
    #endregion

    #region Methods
    static Opus()
    {
        _handle = LibraryLoader.Load( typeof( Opus ) );
    }

    public static int opus_Assert( int err )
    {
        if ( err < 0 )
            throw new Exception( "opus error " + err );

        return err;
    }

    [ExternalMethod]
	public static PFNOPUS_STRERRORPROC opus_strerror;
    [ExternalMethod]
	public static PFNOPUS_GET_VERSION_STRINGPROC opus_get_version_string;
    [ExternalMethod]
	public static PFNOPUS_ENCODER_GET_SIZEPROC opus_encoder_get_size;
    [ExternalMethod]
	public static PFNOPUS_ENCODER_CREATEPROC opus_encoder_create;
    [ExternalMethod]
	public static PFNOPUS_ENCODER_INITPROC opus_encoder_init;
    [ExternalMethod]
	public static PFNOPUS_ENCODEPROC opus_encode;
    [ExternalMethod]
	public static PFNOPUS_ENCODE_FLOATPROC opus_encode_float;
    [ExternalMethod]
	public static PFNOPUS_ENCODER_DESTROYPROC opus_encoder_destroy;
    [ExternalMethod]
	public static PFNOPUS_DECODER_GET_SIZEPROC opus_decoder_get_size;
    [ExternalMethod]
	public static PFNOPUS_DECODER_CREATEPROC opus_decoder_create;
    [ExternalMethod]
	public static PFNOPUS_DECODER_INITPROC opus_decoder_init;
    [ExternalMethod]
	public static PFNOPUS_DECODEPROC opus_decode;
    [ExternalMethod]
	public static PFNOPUS_DECODE_FLOATPROC opus_decode_float;
    [ExternalMethod]
	public static PFNOPUS_DECODER_DESTROYPROC opus_decoder_destroy;
    [ExternalMethod]
	public static PFNOPUS_PACKET_GET_BANDWIDTHPROC opus_packet_get_bandwidth;
    [ExternalMethod]
	public static PFNOPUS_PACKET_GET_SAMPLES_PER_FRAMEPROC opus_packet_get_samples_per_frame;
    [ExternalMethod]
	public static PFNOPUS_PACKET_GET_NB_CHANNELSPROC opus_packet_get_nb_channels;
    [ExternalMethod]
	public static PFNOPUS_PACKET_GET_NB_FRAMESPROC opus_packet_get_nb_frames;
    [ExternalMethod]
	public static PFNOPUS_PACKET_GET_NB_SAMPLESPROC opus_packet_get_nb_samples;
    [ExternalMethod]
	public static PFNOPUS_DECODER_GET_NB_SAMPLESPROC opus_decoder_get_nb_samples;
    [ExternalMethod]
	public static PFNOPUS_PCM_SOFT_CLIPPROC opus_pcm_soft_clip;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_GET_SIZEPROC opus_repacketizer_get_size;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_INITPROC opus_repacketizer_init;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_CREATEPROC opus_repacketizer_create;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_DESTROYPROC opus_repacketizer_destroy;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_CATPROC opus_repacketizer_cat;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_OUT_RANGEPROC opus_repacketizer_out_range;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_GET_NB_FRAMESPROC opus_repacketizer_get_nb_frames;
    [ExternalMethod]
	public static PFNOPUS_REPACKETIZER_OUTPROC opus_repacketizer_out;
    [ExternalMethod]
	public static PFNOPUS_PACKET_PADPROC opus_packet_pad;
    [ExternalMethod]
	public static PFNOPUS_PACKET_UNPADPROC opus_packet_unpad;
    [ExternalMethod]
	public static PFNOPUS_MULTISTREAM_PACKET_PADPROC opus_multistream_packet_pad;
    [ExternalMethod]
	public static PFNOPUS_MULTISTREAM_PACKET_UNPADPROC opus_multistream_packet_unpad;
    [ExternalMethod]
	public static PFNOPUS_ENCODER_CTLPROC opus_encoder_ctl;
    #endregion
}