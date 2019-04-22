#region License
/*
    libsoundio

    The MIT License (Expat)

    Copyright (c) 2015 Andrew Kelley

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
#endregion

#region Using statements
using System;
using System.Text;
using System.Runtime.InteropServices;

using LTP.Interop.InteropServices;
#endregion

[Library( "soundio" )]
public static unsafe class SoundIO
{
    #region Fields / Properties
    private static IntPtr _handle;
	#endregion

	#region Constants
	public const int SOUNDIO_MAX_CHANNELS = 24;

    public static uint SoundIoFormatS16NE = (uint)SoundIoFormat.SoundIoFormatS16BE;
    public static uint SoundIoFormatU16NE = (uint)SoundIoFormat.SoundIoFormatU16BE;
    public static uint SoundIoFormatS24NE = (uint)SoundIoFormat.SoundIoFormatS24BE;
    public static uint SoundIoFormatU24NE = (uint)SoundIoFormat.SoundIoFormatU24BE;
    public static uint SoundIoFormatS32NE = (uint)SoundIoFormat.SoundIoFormatS32BE;
    public static uint SoundIoFormatU32NE = (uint)SoundIoFormat.SoundIoFormatU32BE;
    public static uint SoundIoFormatFloat32NE = (uint)SoundIoFormat.SoundIoFormatFloat32BE;
    public static uint SoundIoFormatFloat64NE = (uint)SoundIoFormat.SoundIoFormatFloat64BE;

    public static uint SoundIoFormatS16FE = (uint)SoundIoFormat.SoundIoFormatS16LE;
    public static uint SoundIoFormatU16FE = (uint)SoundIoFormat.SoundIoFormatU16LE;
    public static uint SoundIoFormatS24FE = (uint)SoundIoFormat.SoundIoFormatS24LE;
    public static uint SoundIoFormatU24FE = (uint)SoundIoFormat.SoundIoFormatU24LE;
    public static uint SoundIoFormatS32FE = (uint)SoundIoFormat.SoundIoFormatS32LE;
    public static uint SoundIoFormatU32FE = (uint)SoundIoFormat.SoundIoFormatU32LE;
    public static uint SoundIoFormatFloat32FE = (uint)SoundIoFormat.SoundIoFormatFloat32LE;
    public static uint SoundIoFormatFloat64FE = (uint)SoundIoFormat.SoundIoFormatFloat64LE;
    #endregion

    #region Enumerations
    public enum SoundIoError : uint
    {
        SoundIoErrorNone,
        SoundIoErrorNoMem,
        SoundIoErrorInitAudioBackend,
        SoundIoErrorSystemResources,
        SoundIoErrorOpeningDevice,
        SoundIoErrorNoSuchDevice,
        SoundIoErrorInvalid,
        SoundIoErrorBackendUnavailable,
        SoundIoErrorStreaming,
        SoundIoErrorIncompatibleDevice,
        SoundIoErrorNoSuchClient,
        SoundIoErrorIncompatibleBackend,
        SoundIoErrorBackendDisconnected,
        SoundIoErrorInterrupted,
        SoundIoErrorUnderflow,
        SoundIoErrorEncodingString,
    }

    public enum SoundIoChannelId : uint
    {
        SoundIoChannelIdInvalid,
        SoundIoChannelIdFrontLeft,
        SoundIoChannelIdFrontRight,
        SoundIoChannelIdFrontCenter,
        SoundIoChannelIdLfe,
        SoundIoChannelIdBackLeft,
        SoundIoChannelIdBackRight,
        SoundIoChannelIdFrontLeftCenter,
        SoundIoChannelIdFrontRightCenter,
        SoundIoChannelIdBackCenter,
        SoundIoChannelIdSideLeft,
        SoundIoChannelIdSideRight,
        SoundIoChannelIdTopCenter,
        SoundIoChannelIdTopFrontLeft,
        SoundIoChannelIdTopFrontCenter,
        SoundIoChannelIdTopFrontRight,
        SoundIoChannelIdTopBackLeft,
        SoundIoChannelIdTopBackCenter,
        SoundIoChannelIdTopBackRight,
        SoundIoChannelIdBackLeftCenter,
        SoundIoChannelIdBackRightCenter,
        SoundIoChannelIdFrontLeftWide,
        SoundIoChannelIdFrontRightWide,
        SoundIoChannelIdFrontLeftHigh,
        SoundIoChannelIdFrontCenterHigh,
        SoundIoChannelIdFrontRightHigh,
        SoundIoChannelIdTopFrontLeftCenter,
        SoundIoChannelIdTopFrontRightCenter,
        SoundIoChannelIdTopSideLeft,
        SoundIoChannelIdTopSideRight,
        SoundIoChannelIdLeftLfe,
        SoundIoChannelIdRightLfe,
        SoundIoChannelIdLfe2,
        SoundIoChannelIdBottomCenter,
        SoundIoChannelIdBottomLeftCenter,
        SoundIoChannelIdBottomRightCenter,
        SoundIoChannelIdMsMid,
        SoundIoChannelIdMsSide,
        SoundIoChannelIdAmbisonicW,
        SoundIoChannelIdAmbisonicX,
        SoundIoChannelIdAmbisonicY,
        SoundIoChannelIdAmbisonicZ,
        SoundIoChannelIdXyX,
        SoundIoChannelIdXyY,
        SoundIoChannelIdHeadphonesLeft,
        SoundIoChannelIdHeadphonesRight,
        SoundIoChannelIdClickTrack,
        SoundIoChannelIdForeignLanguage,
        SoundIoChannelIdHearingImpaired,
        SoundIoChannelIdNarration,
        SoundIoChannelIdHaptic,
        SoundIoChannelIdDialogCentricMix,
        SoundIoChannelIdAux,
        SoundIoChannelIdAux0,
        SoundIoChannelIdAux1,
        SoundIoChannelIdAux2,
        SoundIoChannelIdAux3,
        SoundIoChannelIdAux4,
        SoundIoChannelIdAux5,
        SoundIoChannelIdAux6,
        SoundIoChannelIdAux7,
        SoundIoChannelIdAux8,
        SoundIoChannelIdAux9,
        SoundIoChannelIdAux10,
        SoundIoChannelIdAux11,
        SoundIoChannelIdAux12,
        SoundIoChannelIdAux13,
        SoundIoChannelIdAux14,
        SoundIoChannelIdAux15,
    }

    public enum SoundIoChannelLayoutId : uint
    {
        SoundIoChannelLayoutIdMono,
        SoundIoChannelLayoutIdStereo,
        SoundIoChannelLayoutId2Point1,
        SoundIoChannelLayoutId3Point0,
        SoundIoChannelLayoutId3Point0Back,
        SoundIoChannelLayoutId3Point1,
        SoundIoChannelLayoutId4Point0,
        SoundIoChannelLayoutIdQuad,
        SoundIoChannelLayoutIdQuadSide,
        SoundIoChannelLayoutId4Point1,
        SoundIoChannelLayoutId5Point0Back,
        SoundIoChannelLayoutId5Point0Side,
        SoundIoChannelLayoutId5Point1,
        SoundIoChannelLayoutId5Point1Back,
        SoundIoChannelLayoutId6Point0Side,
        SoundIoChannelLayoutId6Point0Front,
        SoundIoChannelLayoutIdHexagonal,
        SoundIoChannelLayoutId6Point1,
        SoundIoChannelLayoutId6Point1Back,
        SoundIoChannelLayoutId6Point1Front,
        SoundIoChannelLayoutId7Point0,
        SoundIoChannelLayoutId7Point0Front,
        SoundIoChannelLayoutId7Point1,
        SoundIoChannelLayoutId7Point1Wide,
        SoundIoChannelLayoutId7Point1WideBack,
        SoundIoChannelLayoutIdOctagonal,
    }

    public enum SoundIoBackend : uint
    {
        SoundIoBackendNone,
        SoundIoBackendJack,
        SoundIoBackendPulseAudio,
        SoundIoBackendAlsa,
        SoundIoBackendCoreAudio,
        SoundIoBackendWasapi,
        SoundIoBackendDummy,
    }

    public enum SoundIoDeviceAim : uint
    {
        SoundIoDeviceAimInput,
        SoundIoDeviceAimOutput,
    }

    public enum SoundIoFormat : int
    {
        SoundIoFormatInvalid,
        SoundIoFormatS8,
        SoundIoFormatU8,
        SoundIoFormatS16LE,
        SoundIoFormatS16BE,
        SoundIoFormatU16LE,
        SoundIoFormatU16BE,
        SoundIoFormatS24LE,
        SoundIoFormatS24BE,
        SoundIoFormatU24LE,
        SoundIoFormatU24BE,
        SoundIoFormatS32LE,
        SoundIoFormatS32BE,
        SoundIoFormatU32LE,
        SoundIoFormatU32BE,
        SoundIoFormatFloat32LE,
        SoundIoFormatFloat32BE,
        SoundIoFormatFloat64LE,
        SoundIoFormatFloat64BE,
    }
    #endregion

    #region Structs
    [StructLayout( LayoutKind.Sequential )]
    public struct SoundIoChannelLayout
    {
        public byte* name;
        public int channel_count;
        public fixed uint channels[ SOUNDIO_MAX_CHANNELS ];
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct SoundIoSampleRateRange
    {
        public int min;
        public int max;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct SoundIoChannelArea
    {
        public byte* ptr;
        public int step;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct SoundIo
    {
        public void* userdata;
        public void* on_devices_change;
        public void* on_backend_disconnect;
        public void* on_events_signal;
        public SoundIoBackend current_backend;
        public void* app_name;
        public void* emit_rtprio_warninh;
        public void* jack_info_callback;
        public void* jack_error_callback;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct SoundIoDevice
    {
        public SoundIo* soundio;
        public byte* id;
        public byte* name;
        public SoundIoDeviceAim aim;
        public SoundIoChannelLayout* layouts;
        public int layout_count;
        public SoundIoChannelLayout current_layout;
        public SoundIoFormat* formats;
        public int format_count;
        public SoundIoFormat current_format;
        public SoundIoSampleRateRange* sample_rates;
        public int sample_rate_count;
        public int sample_rate_current;
        public double software_latency_min;
        public double software_latency_max;
        public double software_latency_current;
        public bool is_raw;
        public int ref_count;
        public int probe_error;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct SoundIoOutStream
    {
        public void* device;
        public SoundIoFormat format;
        public int sample_rate;
        public SoundIoChannelLayout layout;
        public double software_latency;
        public void* userdata;
        public void* write_callback;
        public void* underflow_callback;
        public void* error_callback;
        public byte* name;
        public bool non_terminal_hint;
        public int bytes_per_frame;
        public int bytes_per_sample;
        public int layout_error;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct SoundIoInStream
    {
        public void* device;
        public SoundIoFormat format;
        public int sample_rate;
        public SoundIoChannelLayout layout;
        public double software_latency;
        public void* userdata;
        public void* read_callback;
        public void* overflow_callback;
        public void* error_callback;
        public byte* name;
        public bool non_terminal_hint;
        public int bytes_per_frame;
        public int bytes_per_sample;
        public int layout_error;
    }
    #endregion

    #region Delegates
    public delegate void SoundIo_on_devices_change( void* soundio );
    public delegate void SoundIo_on_backend_disconnect( void* soundio, int err );
    public delegate void SoundIo_on_events_signal( void* soundio );
    public delegate void SoundIo_emit_rtprio_warning();
    public delegate void SoundIo_jack_info_callback( [In] [MarshalAs( UnmanagedType.LPStr )] string msg );
    public delegate void SoundIo_jack_error_callback( [In] [MarshalAs( UnmanagedType.LPStr )] string msg );
    public delegate void SoundIoOutStream_write_callback( void* stream, int frame_count_min, int frame_count_max );
    public delegate void SoundIoOutStream_underflow_callback( void* stream );
    public delegate void SoundIoOutStream_error_callback( void* stream, int err );
    public delegate void SoundIoInStream_read_callback( void* stream, int frame_count_min, int frame_count_max );
    public delegate void SoundIoInStream_overflow_callback( void* stream );
    public delegate void SoundIoInStream_error_callback( void* stream, int err );

    #region Function prototypes
    public delegate void* PFNSOUNDIO_VERSION_STRINGPROC();
    public delegate int PFNSOUNDIO_VERSION_MAJORPROC();
    public delegate int PFNSOUNDIO_VERSION_MINORPROC();
    public delegate int PFNSOUNDIO_VERSION_PATCHPROC();
    public delegate void* PFNSOUNDIO_CREATEPROC();
    public delegate void PFNSOUNDIO_DESTROYPROC( void* soundio );
    public delegate int PFNSOUNDIO_CONNECTPROC( void* soundio );
    public delegate int PFNSOUNDIO_CONNECT_BACKENDPROC( void* soundio, SoundIoBackend backend );
    public delegate void PFNSOUNDIO_DISCONNECTPROC( void* soundio );
    public delegate void* PFNSOUNDIO_STRERRORPROC( int error );
    public delegate void* PFNSOUNDIO_BACKEND_NAMEPROC( SoundIoBackend backend );
    public delegate int PFNSOUNDIO_BACKEND_COUNTPROC( void* soundio );
    public delegate SoundIoBackend PFNSOUNDIO_GET_BACKENDPROC( void* soundio, int index );
    [return: MarshalAs( UnmanagedType.I1 )]
    public delegate bool PFNSOUNDIO_HAVE_BACKENDPROC( SoundIoBackend backend );
    public delegate void PFNSOUNDIO_FLUSH_EVENTSPROC( void* soundio );
    public delegate void PFNSOUNDIO_WAIT_EVENTSPROC( void* soundio );
    public delegate void PFNSOUNDIO_WAKEUPPROC( void* soundio );
    public delegate void PFNSOUNDIO_FORCE_DEVICE_SCANPROC( void* soundio );
    [return: MarshalAs( UnmanagedType.I1 )]
    public delegate bool PFNSOUNDIO_CHANNEL_LAYOUT_EQUALPROC( void* a, void* b );
    public delegate void* PFNSOUNDIO_GET_CHANNEL_NAMEPROC( SoundIoChannelId id );
    public delegate SoundIoChannelId PFNSOUNDIO_PARSE_CHANNEL_IDPROC( [In] [MarshalAs( UnmanagedType.LPStr )] string str, int str_len );
    public delegate int PFNSOUNDIO_CHANNEL_LAYOUT_BUILTIN_COUNTPROC();
    public delegate void* PFNSOUNDIO_CHANNEL_LAYOUT_GET_BUILTINPROC( int index );
    public delegate void* PFNSOUNDIO_CHANNEL_LAYOUT_GET_DEFAULTPROC( int channel_count );
    public delegate int PFNSOUNDIO_CHANNEL_LAYOUT_FIND_CHANNELPROC( void* layout, SoundIoChannelId channel );
    [return: MarshalAs( UnmanagedType.I1 )]
    public delegate bool PFNSOUNDIO_CHANNEL_LAYOUT_DETECT_BUILTINPROC( void* layout );
    public delegate void* PFNSOUNDIO_BEST_MATCHING_CHANNEL_LAYOUTPROC( void* preferred_layouts, int preferred_layout_count, void* available_layouts, int available_layout_count );
    public delegate void PFNSOUNDIO_SORT_CHANNEL_LAYOUTSPROC( void* layouts, int layout_count );
    public delegate int PFNSOUNDIO_GET_BYTES_PER_SAMPLEPROC( SoundIoFormat format );
    public delegate void* PFNSOUNDIO_FORMAT_STRINGPROC( SoundIoFormat format );
    public delegate int PFNSOUNDIO_INPUT_DEVICE_COUNTPROC( void* soundio );
    public delegate int PFNSOUNDIO_OUTPUT_DEVICE_COUNTPROC( void* soundio );
    public delegate void* PFNSOUNDIO_GET_INPUT_DEVICEPROC( void* soundio, int index );
    public delegate void* PFNSOUNDIO_GET_OUTPUT_DEVICEPROC( void* soundio, int index );
    public delegate int PFNSOUNDIO_DEFAULT_INPUT_DEVICE_INDEXPROC( void* soundio );
    public delegate int PFNSOUNDIO_DEFAULT_OUTPUT_DEVICE_INDEXPROC( void* soundio );
    public delegate void PFNSOUNDIO_DEVICE_REFPROC( void* device );
    public delegate void PFNSOUNDIO_DEVICE_UNREFPROC( void* device );
    [return: MarshalAs( UnmanagedType.I1 )]
    public delegate bool PFNSOUNDIO_DEVICE_EQUALPROC( void* a, void* b );
    public delegate void PFNSOUNDIO_DEVICE_SORT_CHANNEL_LAYOUTSPROC( void* device );
    [return: MarshalAs( UnmanagedType.I1 )]
    public delegate bool PFNSOUNDIO_DEVICE_SUPPORTS_FORMATPROC( void* device, SoundIoFormat format );
    [return: MarshalAs( UnmanagedType.I1 )]
    public delegate bool PFNSOUNDIO_DEVICE_SUPPORTS_LAYOUTPROC( void* device, void* layout );
    [return: MarshalAs( UnmanagedType.I1 )]
    public delegate bool PFNSOUNDIO_DEVICE_SUPPORTS_SAMPLE_RATEPROC( void* device, int sample_rate );
    public delegate int PFNSOUNDIO_DEVICE_NEAREST_SAMPLE_RATEPROC( void* device, int sample_rate );
    public delegate void* PFNSOUNDIO_OUTSTREAM_CREATEPROC( void* device );
    public delegate void PFNSOUNDIO_OUTSTREAM_DESTROYPROC( void* outstream );
    public delegate int PFNSOUNDIO_OUTSTREAM_OPENPROC( void* outstream );
    public delegate int PFNSOUNDIO_OUTSTREAM_STARTPROC( void* outstream );
    public delegate int PFNSOUNDIO_OUTSTREAM_BEGIN_WRITEPROC( void* outstream, void** areas, int* frame_count );
    public delegate int PFNSOUNDIO_OUTSTREAM_END_WRITEPROC( void* outstream );
    public delegate int PFNSOUNDIO_OUTSTREAM_CLEAR_BUFFERPROC( void* outstream );
    public delegate int PFNSOUNDIO_OUTSTREAM_PAUSEPROC( void* outstream, [MarshalAs( UnmanagedType.I1 )] bool pause );
    public delegate int PFNSOUNDIO_OUTSTREAM_GET_LATENCYPROC( void* outstream, ref double out_latency );
    public delegate void* PFNSOUNDIO_INSTREAM_CREATEPROC( void* device );
    public delegate void PFNSOUNDIO_INSTREAM_DESTROYPROC( void* instream );
    public delegate int PFNSOUNDIO_INSTREAM_OPENPROC( void* instream );
    public delegate int PFNSOUNDIO_INSTREAM_STARTPROC( void* instream );
    public delegate int PFNSOUNDIO_INSTREAM_BEGIN_READPROC( void* instream, void** areas, int* frame_count );
    public delegate int PFNSOUNDIO_INSTREAM_END_READPROC( void* instream );
    public delegate int PFNSOUNDIO_INSTREAM_PAUSEPROC( void* instream, [MarshalAs( UnmanagedType.I1 )] bool pause );
    public delegate int PFNSOUNDIO_INSTREAM_GET_LATENCYPROC( void* instream, ref double out_latency );
    public delegate void* PFNSOUNDIO_RING_BUFFER_CREATEPROC( void* soundio, int requested_capacity );
    public delegate void PFNSOUNDIO_RING_BUFFER_DESTROYPROC( void* ring_buffer );
    public delegate int PFNSOUNDIO_RING_BUFFER_CAPACITYPROC( void* ring_buffer );
    public delegate void* PFNSOUNDIO_RING_BUFFER_WRITE_PTRPROC( void* ring_buffer );
    public delegate void PFNSOUNDIO_RING_BUFFER_ADVANCE_WRITE_PTRPROC( void* ring_buffer, int count );
    public delegate void* PFNSOUNDIO_RING_BUFFER_READ_PTRPROC( void* ring_buffer );
    public delegate void PFNSOUNDIO_RING_BUFFER_ADVANCE_READ_PTRPROC( void* ring_buffer, int count );
    public delegate int PFNSOUNDIO_RING_BUFFER_FILL_COUNTPROC( void* ring_buffer );
    public delegate int PFNSOUNDIO_RING_BUFFER_FREE_COUNTPROC( void* ring_buffer );
    public delegate void PFNSOUNDIO_RING_BUFFER_CLEARPROC( void* ring_buffer );
	#endregion
	#endregion

	#region Constructors
	static SoundIO()
	{
		_handle = LibraryLoader.Load( typeof( SoundIO ) );

		if( BitConverter.IsLittleEndian )
		{
			SoundIoFormatS16NE = (uint)SoundIoFormat.SoundIoFormatS16LE;
			SoundIoFormatU16NE = (uint)SoundIoFormat.SoundIoFormatU16LE;
			SoundIoFormatS24NE = (uint)SoundIoFormat.SoundIoFormatS24LE;
			SoundIoFormatU24NE = (uint)SoundIoFormat.SoundIoFormatU24LE;
			SoundIoFormatS32NE = (uint)SoundIoFormat.SoundIoFormatS32LE;
			SoundIoFormatU32NE = (uint)SoundIoFormat.SoundIoFormatU32LE;
			SoundIoFormatFloat32NE = (uint)SoundIoFormat.SoundIoFormatFloat32LE;
			SoundIoFormatFloat64NE = (uint)SoundIoFormat.SoundIoFormatFloat64LE;

			SoundIoFormatS16FE = (uint)SoundIoFormat.SoundIoFormatS16BE;
			SoundIoFormatU16FE = (uint)SoundIoFormat.SoundIoFormatU16BE;
			SoundIoFormatS24FE = (uint)SoundIoFormat.SoundIoFormatS24BE;
			SoundIoFormatU24FE = (uint)SoundIoFormat.SoundIoFormatU24BE;
			SoundIoFormatS32FE = (uint)SoundIoFormat.SoundIoFormatS32BE;
			SoundIoFormatU32FE = (uint)SoundIoFormat.SoundIoFormatU32BE;
			SoundIoFormatFloat32FE = (uint)SoundIoFormat.SoundIoFormatFloat32BE;
			SoundIoFormatFloat64FE = (uint)SoundIoFormat.SoundIoFormatFloat64BE;
		}
	}
	#endregion

	#region Methods
	public static void soundio_Assert( int err )
    {
        if( err == 0 )
            return;

		byte* strErrPtr = (byte*)soundio_strerror( err );
		byte* offset = strErrPtr;

		while( offset++[ 0 ] != 0x00 ) ;

		throw new Exception( err + " " + Encoding.ASCII.GetString( strErrPtr, (int)( offset - strErrPtr ) ) );
    } 

    public static void soundio_Assert( void* ptr )
    {
        if( ptr == (void*)0 )
            throw new OutOfMemoryException();
    }

    [ExternalMethod]
	public static PFNSOUNDIO_VERSION_STRINGPROC soundio_version_string;
    [ExternalMethod]
	public static PFNSOUNDIO_VERSION_MAJORPROC soundio_version_major;
    [ExternalMethod]
	public static PFNSOUNDIO_VERSION_MINORPROC soundio_version_minor;
    [ExternalMethod]
	public static PFNSOUNDIO_VERSION_PATCHPROC soundio_version_patch;
    [ExternalMethod]
	public static PFNSOUNDIO_CREATEPROC soundio_create;
    [ExternalMethod]
	public static PFNSOUNDIO_DESTROYPROC soundio_destroy;
    [ExternalMethod]
	public static PFNSOUNDIO_CONNECTPROC soundio_connect;
    [ExternalMethod]
	public static PFNSOUNDIO_CONNECT_BACKENDPROC soundio_connect_backend;
    [ExternalMethod]
	public static PFNSOUNDIO_DISCONNECTPROC soundio_disconnect;
    [ExternalMethod]
	public static PFNSOUNDIO_STRERRORPROC soundio_strerror;
    [ExternalMethod]
	public static PFNSOUNDIO_BACKEND_NAMEPROC soundio_backend_name;
    [ExternalMethod]
	public static PFNSOUNDIO_BACKEND_COUNTPROC soundio_backend_count;
    [ExternalMethod]
	public static PFNSOUNDIO_GET_BACKENDPROC soundio_get_backend;
    [ExternalMethod]
	public static PFNSOUNDIO_HAVE_BACKENDPROC soundio_have_backend;
    [ExternalMethod]
	public static PFNSOUNDIO_FLUSH_EVENTSPROC soundio_flush_events;
    [ExternalMethod]
	public static PFNSOUNDIO_WAIT_EVENTSPROC soundio_wait_events;
    [ExternalMethod]
	public static PFNSOUNDIO_WAKEUPPROC soundio_wakeup;
    [ExternalMethod]
	public static PFNSOUNDIO_FORCE_DEVICE_SCANPROC soundio_force_device_scan;
    [ExternalMethod]
	public static PFNSOUNDIO_CHANNEL_LAYOUT_EQUALPROC soundio_channel_layout_equal;
    [ExternalMethod]
	public static PFNSOUNDIO_GET_CHANNEL_NAMEPROC soundio_get_channel_name;
    [ExternalMethod]
	public static PFNSOUNDIO_PARSE_CHANNEL_IDPROC soundio_parse_channel_id;
    [ExternalMethod]
	public static PFNSOUNDIO_CHANNEL_LAYOUT_BUILTIN_COUNTPROC soundio_channel_layout_builtin_count;
    [ExternalMethod]
	public static PFNSOUNDIO_CHANNEL_LAYOUT_GET_BUILTINPROC soundio_channel_layout_get_builtin;
    [ExternalMethod]
	public static PFNSOUNDIO_CHANNEL_LAYOUT_GET_DEFAULTPROC soundio_channel_layout_get_default;
    [ExternalMethod]
	public static PFNSOUNDIO_CHANNEL_LAYOUT_FIND_CHANNELPROC soundio_channel_layout_find_channel;
    [ExternalMethod]
	public static PFNSOUNDIO_CHANNEL_LAYOUT_DETECT_BUILTINPROC soundio_channel_layout_detect_builtin;
    [ExternalMethod]
	public static PFNSOUNDIO_BEST_MATCHING_CHANNEL_LAYOUTPROC soundio_best_matching_channel_layout;
    [ExternalMethod]
	public static PFNSOUNDIO_SORT_CHANNEL_LAYOUTSPROC soundio_sort_channel_layouts;
    [ExternalMethod]
	public static PFNSOUNDIO_GET_BYTES_PER_SAMPLEPROC soundio_get_bytes_per_sample;
    [ExternalMethod]
	public static PFNSOUNDIO_FORMAT_STRINGPROC soundio_format_string;
    [ExternalMethod]
	public static PFNSOUNDIO_INPUT_DEVICE_COUNTPROC soundio_input_device_count;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTPUT_DEVICE_COUNTPROC soundio_output_device_count;
    [ExternalMethod]
	public static PFNSOUNDIO_GET_INPUT_DEVICEPROC soundio_get_input_device;
    [ExternalMethod]
	public static PFNSOUNDIO_GET_OUTPUT_DEVICEPROC soundio_get_output_device;
    [ExternalMethod]
	public static PFNSOUNDIO_DEFAULT_INPUT_DEVICE_INDEXPROC soundio_default_input_device_index;
    [ExternalMethod]
	public static PFNSOUNDIO_DEFAULT_OUTPUT_DEVICE_INDEXPROC soundio_default_output_device_index;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_REFPROC soundio_device_ref;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_UNREFPROC soundio_device_unref;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_EQUALPROC soundio_device_equal;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_SORT_CHANNEL_LAYOUTSPROC soundio_device_sort_channel_layouts;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_SUPPORTS_FORMATPROC soundio_device_supports_format;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_SUPPORTS_LAYOUTPROC soundio_device_supports_layout;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_SUPPORTS_SAMPLE_RATEPROC soundio_device_supports_sample_rate;
    [ExternalMethod]
	public static PFNSOUNDIO_DEVICE_NEAREST_SAMPLE_RATEPROC soundio_device_nearest_sample_rate;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_CREATEPROC soundio_outstream_create;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_DESTROYPROC soundio_outstream_destroy;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_OPENPROC soundio_outstream_open;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_STARTPROC soundio_outstream_start;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_BEGIN_WRITEPROC soundio_outstream_begin_write;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_END_WRITEPROC soundio_outstream_end_write;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_CLEAR_BUFFERPROC soundio_outstream_clear_buffer;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_PAUSEPROC soundio_outstream_pause;
    [ExternalMethod]
	public static PFNSOUNDIO_OUTSTREAM_GET_LATENCYPROC soundio_outstream_get_latency;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_CREATEPROC soundio_instream_create;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_DESTROYPROC soundio_instream_destroy;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_OPENPROC soundio_instream_open;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_STARTPROC soundio_instream_start;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_BEGIN_READPROC soundio_instream_begin_read;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_END_READPROC soundio_instream_end_read;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_PAUSEPROC soundio_instream_pause;
    [ExternalMethod]
	public static PFNSOUNDIO_INSTREAM_GET_LATENCYPROC soundio_instream_get_latency;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_CREATEPROC soundio_ring_buffer_create;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_DESTROYPROC soundio_ring_buffer_destroy;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_CAPACITYPROC soundio_ring_buffer_capacity;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_WRITE_PTRPROC soundio_ring_buffer_write_ptr;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_ADVANCE_WRITE_PTRPROC soundio_ring_buffer_advance_write_ptr;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_READ_PTRPROC soundio_ring_buffer_read_ptr;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_ADVANCE_READ_PTRPROC soundio_ring_buffer_advance_read_ptr;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_FILL_COUNTPROC soundio_ring_buffer_fill_count;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_FREE_COUNTPROC soundio_ring_buffer_free_count;
    [ExternalMethod]
	public static PFNSOUNDIO_RING_BUFFER_CLEARPROC soundio_ring_buffer_clear;
    #endregion
}
