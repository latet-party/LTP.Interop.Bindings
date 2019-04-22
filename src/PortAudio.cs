#region License
/*
    PortAudio Portable Real-Time Audio Library
    Copyright (c) 1999-2011 Ross Bencina and Phil Burk

    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

        The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

#region Using statements
using System;
using System.Runtime.InteropServices;

using LTP.Interop.InteropServices;
#endregion

[Library( "portaudio" )]
public static unsafe class PortAudio
{
    #region Fields / Properties
    private static IntPtr _handle;
    #endregion

    #region Constructors
    static PortAudio()
    {
        _handle = LibraryLoader.Load( typeof( PortAudio ) );

        Pa_Assert( Pa_Initialize() );
    }
    #endregion

    #region Enumerations
    public enum PaErrorCode : int
    {
        NoError = 0,
        NotInitialized = -10000,
        UnanticitedHostError,
        InvalidChannelCount,
        InvalidSampleRate,
        InvalidDevice,
        InvalidFlag,
        SampleFormatNotSupported,
        BadIODeviceCombination,
        InsufficientMemory,
        BufferTooBig,
        BufferTooSmall,
        NullCallback,
        BadStreamPtr,
        TimedOut,
        InternalError,
        DeviceUnavailable,
        IncomtibleHostApiSpecificStreamInfo,
        StreamIsStopped,
        StreamIsNotStopped,
        InputOverflowed,
        OutputUnderflowed,
        HostApiNotFound,
        InvalidHostApi,
        CanNotReadFromACallbackStream,
        CanNotWriteToACallbackStream,
        CanNotReadFromAnOutputOnlyStream,
        CanNotWriteToAnInputOnlyStream,
        IncomtibleStreamHostApi,
        BadBufferPtr,
    }

    public enum PaHostApiTypeId
    {
        InDevelopment = 0,
        DirectSound = 1,
        MME = 2,
        ASIO = 3,
        SoundManager = 4,
        CoreAudio = 5,
        OSS = 7,
        ALSA = 8,
        AL = 9,
        BeOS = 10,
        WDMKS = 11,
        JACK = 12,
        WASAPI = 13,
        AudioScienceHPI = 14,
    }

    public enum PaStreamCallbackResult
    {
        Continue = 0,
        Complete = 1,
        Abort = 2,
    }

    [Flags]
    public enum PaSampleFormat : uint
    {
        Float32 = 0x00000001,
        Int32 = 0x00000002,
        Int24 = 0x00000004,
        Int16 = 0x00000008,
        Int8 = 0x00000010,
        UInt8 = 0x00000020,
        CustomFormat = 0x00010000,
        NonInterleaved = 0x80000000
    }

    [Flags]
    public enum PaStreamFlags : uint
    {
        NoFlag = 0,
        Clipoff = 0x00000001,
        Ditheroff = 0x00000002,
        NeverDropInput = 0x00000004,
        PrimeOutputBuffersUsingStreamCallback = 0x00000008,
        PlatformSpecificFlags = 0xFFFF0000
    }

    [Flags]
    public enum PaStreamCallbackFlags : uint
    {
        InputUnderflow = 0x00000001,
        InputOverflow = 0x00000002,
        OutputUnderflow = 0x00000004,
        OutputOverflow = 0x00000008,
        PrimingOutput = 0x00000010
    }
    #endregion

    #region Structs
    [StructLayout( LayoutKind.Sequential )]
    public struct PaVersionInfo
    {
        public int versionMajor;
        public int versionMinor;
        public int versionSubMinor;
        public byte* versionControlRevision;
        public byte* versionText;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct PaHostApiInfo
    {
        public int structVersion;
        public PaHostApiTypeId type;
        public byte* name;
        public int deviceCount;
        public int defaultInputDevice;
        public int defaultOutputDevice;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct PaHostErrorInfo
    {
        public PaHostApiTypeId hostApiType;
        public PaErrorCode errorCode;
        public byte* errorText;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct PaDeviceInfo
    {
        public int structVersion;
        public byte* name;
        public int hostApi;
        public int maxInputChannels;
        public int maxOutputChannels;
        public double defaultLowInputLatency;
        public double defaultLowOutputLatency;
        public double defaultHighInputLatency;
        public double defaultHighOutputLatency;
        public double defaultSampleRate;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct PaStreamParameters
    {
        public int device;
        public int channelCount;
        public PaSampleFormat sampleFormat;
        public double suggestedLatency;
        public PaStreamInfo* hostApiSpecificStreamInfo;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct PaStreamCallbackTimeInfo
    {
        public double inputBufferAdcTime;
        public double currentTime;
        public double outputBufferDacTime;
    }

    [StructLayout( LayoutKind.Sequential )]
    public struct PaStreamInfo
    {
        public int structVersion;
        public double inputLatency;
        public double outputLatency;
        public double sampleRate;
    }
    #endregion

    #region Delegates
    public delegate PaStreamCallbackResult PaStreamCallback( void* input, void* output, uint frameCount, PaStreamCallbackTimeInfo* timeInfo, uint statusFlags, void* userData );
    public delegate void PaStreamFinishedCallback( void* userData );

    public delegate int PFNPA_GETVERSIONPROC();
    public delegate byte* PFNPA_GETVERSIONTEXTPROC();
    public delegate byte* PFNPA_GETERRORTEXTPROC( PaErrorCode errorCode );
    public delegate PaErrorCode PFNPA_INITIALIZEPROC();
    public delegate PaErrorCode PFNPA_TERMINATEPROC();
    public delegate int PFNPA_GETHOSTAPICOUNTPROC();
    public delegate int PFNPA_GETDEFAULTHOSTAPIPROC();
    public delegate PaHostApiInfo* PFNPA_GETHOSTAPIINFOPROC( int hostApi );
    public delegate int PFNPA_HOSTAPITYPEIDTOHOSTAPIINDEXPROC( PaHostApiTypeId type );
    public delegate int PFNPA_HOSTAPIDEVICEINDEXTODEVICEINDEXPROC( int hostApi, int hostApiDeviceIndex );
    public delegate PaHostErrorInfo* PFNPA_GETLASTHOSTERRORINFOPROC();
    public delegate int PFNPA_GETDEVICECOUNTPROC();
    public delegate int PFNPA_GETDEFAULTINPUTDEVICEPROC();
    public delegate int PFNPA_GETDEFAULTOUTPUTDEVICEPROC();
    public delegate PaDeviceInfo* PFNPA_GETDEVICEINFOPROC( int device );
    public delegate PaErrorCode PFNPA_ISFORMATSUPPORTEDPROC( PaStreamParameters* inputParameters, PaStreamParameters* outputParameters, double sampleRate );
    public delegate PaErrorCode PFNPA_OPENSTREAMPROC( void** stream, PaStreamParameters* inputParameters, PaStreamParameters* outputParameters, double sampleRate, uint framesPerBuffer, PaStreamFlags streamFlags, IntPtr streamCallback, void* userData );
    public delegate PaErrorCode PFNPA_OPENDEFAULTSTREAMPROC( void** stream, int numInputChannels, int numOutputChannels, PaSampleFormat sampleFormat, double sampleRate, uint framesPerBuffer, IntPtr streamCallback, void* userData );
    public delegate PaErrorCode PFNPA_CLOSESTREAMPROC( void* stream );
    public delegate PaErrorCode PFNPA_SETSTREAMFINISHEDCALLBACKPROC( void* stream, IntPtr streamFinishedCallback );
    public delegate PaErrorCode PFNPA_STARTSTREAMPROC( void* stream );
    public delegate PaErrorCode PFNPA_STOPSTREAMPROC( void* stream );
    public delegate PaErrorCode PFNPA_ABORTSTREAMPROC( void* stream );
    public delegate PaErrorCode PFNPA_ISSTREAMSTOPPEDPROC( void* stream );
    public delegate PaErrorCode PFNPA_ISSTREAMACTIVEPROC( void* stream );
    public delegate PaStreamInfo* PFNPA_GETSTREAMINFOPROC( void* stream );
    public delegate double PFNPA_GETSTREAMTIMEPROC( void* stream );
    public delegate double PFNPA_GETSTREAMCPULOADPROC( void* stream );
    public delegate PaErrorCode PFNPA_READSTREAMPROC( void* stream, void* buffer, uint frames );
    public delegate PaErrorCode PFNPA_WRITESTREAMPROC( void* stream, void* buffer, uint frames );
    public delegate int PFNPA_GETSTREAMREADAVAILABLEPROC( void* stream );
    public delegate int PFNPA_GETSTREAMWRITEAVAILABLEPROC( void* stream );
    public delegate PaErrorCode PFNPA_GETSAMPLESIZEPROC( uint format );
    public delegate void PFNPA_SLEEPPROC( int msec );
    #endregion

    #region Methods
    public static void Pa_Assert( PaErrorCode status )
    {
        if( status != PaErrorCode.NoError )
            throw new Exception( status.ToString() );
    }

    [ExternalMethod]
	public static PFNPA_GETVERSIONPROC Pa_GetVersion;
    [ExternalMethod]
	public static PFNPA_GETVERSIONTEXTPROC Pa_GetVersionText;
    [ExternalMethod]
	public static PFNPA_GETERRORTEXTPROC Pa_GetErrorText;
    [ExternalMethod]
	public static PFNPA_INITIALIZEPROC Pa_Initialize;
    [ExternalMethod]
	public static PFNPA_TERMINATEPROC Pa_Terminate;
    [ExternalMethod]
	public static PFNPA_GETHOSTAPICOUNTPROC Pa_GetHostApiCount;
    [ExternalMethod]
	public static PFNPA_GETDEFAULTHOSTAPIPROC Pa_GetDefaultHostApi;
    [ExternalMethod]
	public static PFNPA_GETHOSTAPIINFOPROC Pa_GetHostApiInfo;
    [ExternalMethod]
	public static PFNPA_HOSTAPITYPEIDTOHOSTAPIINDEXPROC Pa_HostApiTypeIdToHostApiIndex;
    [ExternalMethod]
	public static PFNPA_HOSTAPIDEVICEINDEXTODEVICEINDEXPROC Pa_HostApiDeviceIndexToDeviceIndex;
    [ExternalMethod]
	public static PFNPA_GETLASTHOSTERRORINFOPROC Pa_GetLastHostErrorInfo;
    [ExternalMethod]
	public static PFNPA_GETDEVICECOUNTPROC Pa_GetDeviceCount;
    [ExternalMethod]
	public static PFNPA_GETDEFAULTINPUTDEVICEPROC Pa_GetDefaultInputDevice;
    [ExternalMethod]
	public static PFNPA_GETDEFAULTOUTPUTDEVICEPROC Pa_GetDefaultOutputDevice;
    [ExternalMethod]
	public static PFNPA_GETDEVICEINFOPROC Pa_GetDeviceInfo;
    [ExternalMethod]
	public static PFNPA_ISFORMATSUPPORTEDPROC Pa_IsFormatSupported;
    [ExternalMethod]
	public static PFNPA_OPENSTREAMPROC Pa_OpenStream;
    [ExternalMethod]
	public static PFNPA_OPENDEFAULTSTREAMPROC Pa_OpenDefaultStream;
    [ExternalMethod]
	public static PFNPA_CLOSESTREAMPROC Pa_CloseStream;
    [ExternalMethod]
	public static PFNPA_SETSTREAMFINISHEDCALLBACKPROC Pa_SetStreamFinishedCallback;
    [ExternalMethod]
	public static PFNPA_STARTSTREAMPROC Pa_StartStream;
    [ExternalMethod]
	public static PFNPA_STOPSTREAMPROC Pa_StopStream;
    [ExternalMethod]
	public static PFNPA_ABORTSTREAMPROC Pa_AbortStream;
    [ExternalMethod]
	public static PFNPA_ISSTREAMSTOPPEDPROC Pa_IsStreamStopped;
    [ExternalMethod]
	public static PFNPA_ISSTREAMACTIVEPROC Pa_IsStreamActive;
    [ExternalMethod]
	public static PFNPA_GETSTREAMINFOPROC Pa_GetStreamInfo;
    [ExternalMethod]
	public static PFNPA_GETSTREAMTIMEPROC Pa_GetStreamTime;
    [ExternalMethod]
	public static PFNPA_GETSTREAMCPULOADPROC Pa_GetStreamCpuLoad;
    [ExternalMethod]
	public static PFNPA_READSTREAMPROC Pa_ReadStream;
    [ExternalMethod]
	public static PFNPA_WRITESTREAMPROC Pa_WriteStream;
    [ExternalMethod]
	public static PFNPA_GETSTREAMREADAVAILABLEPROC Pa_GetStreamReadAvailable;
    [ExternalMethod]
	public static PFNPA_GETSTREAMWRITEAVAILABLEPROC Pa_GetStreamWriteAvailable;
    [ExternalMethod]
	public static PFNPA_GETSAMPLESIZEPROC Pa_GetSampleSize;
    [ExternalMethod]
	public static PFNPA_SLEEPPROC Pa_Sleep;
    #endregion
}