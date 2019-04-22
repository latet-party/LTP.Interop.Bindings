#region License
/*
	SoLoud audio engine
	Copyright (c) 2013-2015 Jari Komppa

	This software is provided 'as-is', without any express or implied
	warranty. In no event will the authors be held liable for any damages
	arising from the use of this software.

	Permission is granted to anyone to use this software for any purpose,
	including commercial applications, and to alter it and redistribute it
	freely, subject to the following restrictions:

	1. The origin of this software must not be misrepresented; you must not
	claim that you wrote the original software. If you use this software
	in a product, an acknowledgment in the product documentation would be
	appreciated but is not required.

	2. Altered source versions must be plainly marked as such, and must 
	not be misrepresented as being the original software.

	3. This notice may not be removed or altered from any source
	distribution.
*/
#endregion

#region Using statements
using System;
using System.Runtime.InteropServices;

using LTP.Interop.InteropServices;
#endregion

[Library( "soloud" )]
public static unsafe class SoLoud
{
	#region Fields / Properties
	private static IntPtr _handle;
	#endregion

	#region Constructors
	static SoLoud()
	{
		_handle = LibraryLoader.Load( typeof( SoLoud ) );
	}
	#endregion
		
	#region Constants
	public const int SOLOUD_SDL2 = 2;
	public const int SOLOUD_SDL = 1;
	public const int SOLOUD_BACKEND_MAX = 13;
	public const int SOLOUD_WINMM = 4;
	public const int SOLOUD_XAUDIO2 = 5;
	public const int SOLOUD_OSS = 8;
	public const int SOLOUD_WASAPI = 6;
	public const int SOLOUD_CLIP_ROUNDOFF = 1;
	public const int SOLOUD_NULLDRIVER = 12;
	public const int SOLOUD_LEFT_HANDED_3D = 4;
	public const int SOLOUD_ENABLE_VISUALIZATION = 2;
	public const int SOLOUD_OPENAL = 9;
	public const int SOLOUD_ALSA = 7;
	public const int SOLOUD_COREAUDIO = 10;
	public const int SOLOUD_AUTO = 0;
	public const int SOLOUD_PORTAUDIO = 3;
	public const int SOLOUD_OPENSLES = 11;
	public const int SOLOUD_SAMPLERATE = 1;
	public const int SOLOUD_FREQUENCY = 2;
	public const int SOLOUD_RESONANCE = 3;
	public const int SOLOUD_BANDPASS = 3;
	public const int SOLOUD_LOWPASS = 1;
	public const int SOLOUD_WET = 0;
	public const int SOLOUD_HIGHPASS = 2;
	public const int SOLOUD_NONE = 0;
	public const int SOLOUD_BITDEPTH = 2;
	public const int SOLOUD_BOOST = 1;
	public const int SOLOUD_HURT = 4;
	public const int SOLOUD_LASER = 1;
	public const int SOLOUD_BLIP = 6;
	public const int SOLOUD_JUMP = 5;
	public const int SOLOUD_POWERUP = 3;
	public const int SOLOUD_COIN = 0;
	public const int SOLOUD_EXPLOSION = 2;
	public const int SOLOUD_FREQ = 2;
	public const int SOLOUD_DELAY = 1;
	public const int SOLOUD_SIN = 2;
	public const int SOLOUD_SQUARE = 0;
	public const int SOLOUD_SAWSIN = 3;
	public const int SOLOUD_SAW = 1;
	#endregion

	#region Delegates
	public delegate void* PFNSOLOUD_CREATEPROC();
	public delegate void* PFNSOLOUD_DESTROYPROC( void* aObjHandle );
	public delegate int PFNSOLOUD_INITEXPROC( void* aObjHandle, uint aFlags, uint aBackend, uint aSamplerate, uint aBufferSize, uint aChannels );
	public delegate void PFNSOLOUD_DEINITPROC( void* aObjHandle );
	public delegate uint PFNSOLOUD_GETVERSIONPROC( void* aObjHandle );
	public delegate void* PFNSOLOUD_GETERRORSTRINGPROC( void* aObjHandle, int aErrorCode );
	public delegate uint PFNSOLOUD_GETBACKENDIDPROC( void* aObjHandle );
	public delegate void* PFNSOLOUD_GETBACKENDSTRINGPROC( void* aObjHandle );
	public delegate uint PFNSOLOUD_GETBACKENDCHANNELSPROC( void* aObjHandle );
	public delegate uint PFNSOLOUD_GETBACKENDSAMPLERATEPROC( void* aObjHandle );
	public delegate uint PFNSOLOUD_GETBACKENDBUFFERSIZEPROC( void* aObjHandle );
	public delegate int PFNSOLOUD_SETSPEAKERPOSITIONPROC( void* aObjHandle, uint aChannel, float aX, float aY, float aZ );
	public delegate uint PFNSOLOUD_PLAYEXPROC( void* aObjHandle, void* aSound, float aVolume, float aPan, int aPaused, uint aBus );
	public delegate uint PFNSOLOUD_PLAYCLOCKEDEXPROC( void* aObjHandle, double aSoundTime, void* aSound, float aVolume, float aPan, uint aBus );
	public delegate uint PFNSOLOUD_PLAY3DEXPROC( void* aObjHandle, void* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume, int aPaused, uint aBus );
	public delegate uint PFNSOLOUD_PLAY3DCLOCKEDEXPROC( void* aObjHandle, double aSoundTime, void* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume, uint aBus );
	public delegate void PFNSOLOUD_SEEKPROC( void* aObjHandle, uint aVoiceHandle, double aSeconds );
	public delegate void PFNSOLOUD_STOPPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate void PFNSOLOUD_STOPALLPROC( void* aObjHandle );
	public delegate void PFNSOLOUD_STOPAUDIOSOURCEPROC( void* aObjHandle, void* aSound );
	public delegate void PFNSOLOUD_SETFILTERPARAMETERPROC( void* aObjHandle, uint aVoiceHandle, uint aFilterId, uint aAttributeId, float aValue );
	public delegate float PFNSOLOUD_GETFILTERPARAMETERPROC( void* aObjHandle, uint aVoiceHandle, uint aFilterId, uint aAttributeId );
	public delegate void PFNSOLOUD_FADEFILTERPARAMETERPROC( void* aObjHandle, uint aVoiceHandle, uint aFilterId, uint aAttributeId, float aTo, double aTime );
	public delegate void PFNSOLOUD_OSCILLATEFILTERPARAMETERPROC( void* aObjHandle, uint aVoiceHandle, uint aFilterId, uint aAttributeId, float aFrom, float aTo, double aTime );
	public delegate double PFNSOLOUD_GETSTREAMTIMEPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate int PFNSOLOUD_GETPAUSEPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate float PFNSOLOUD_GETVOLUMEPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate float PFNSOLOUD_GETOVERALLVOLUMEPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate float PFNSOLOUD_GETPANPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate float PFNSOLOUD_GETSAMPLERATEPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate int PFNSOLOUD_GETPROTECTVOICEPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate uint PFNSOLOUD_GETACTIVEVOICECOUNTPROC( void* aObjHandle );
	public delegate uint PFNSOLOUD_GETVOICECOUNTPROC( void* aObjHandle );
	public delegate int PFNSOLOUD_ISVALIDVOICEHANDLEPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate float PFNSOLOUD_GETRELATIVEPLAYSPEEDPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate float PFNSOLOUD_GETPOSTCLIPSCALERPROC( void* aObjHandle );
	public delegate float PFNSOLOUD_GETGLOBALVOLUMEPROC( void* aObjHandle );
	public delegate uint PFNSOLOUD_GETMAXACTIVEVOICECOUNTPROC( void* aObjHandle );
	public delegate int PFNSOLOUD_GETLOOPINGPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate void PFNSOLOUD_SETLOOPINGPROC( void* aObjHandle, uint aVoiceHandle, int aLooping );
	public delegate int PFNSOLOUD_SETMAXACTIVEVOICECOUNTPROC( void* aObjHandle, uint aVoiceCount );
	public delegate void PFNSOLOUD_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, uint aVoiceHandle, int aMustTick, int aKill );
	public delegate void PFNSOLOUD_SETGLOBALVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNSOLOUD_SETPOSTCLIPSCALERPROC( void* aObjHandle, float aScaler );
	public delegate void PFNSOLOUD_SETPAUSEPROC( void* aObjHandle, uint aVoiceHandle, int aPause );
	public delegate void PFNSOLOUD_SETPAUSEALLPROC( void* aObjHandle, int aPause );
	public delegate int PFNSOLOUD_SETRELATIVEPLAYSPEEDPROC( void* aObjHandle, uint aVoiceHandle, float aSpeed );
	public delegate void PFNSOLOUD_SETPROTECTVOICEPROC( void* aObjHandle, uint aVoiceHandle, int aProtect );
	public delegate void PFNSOLOUD_SETSAMPLERATEPROC( void* aObjHandle, uint aVoiceHandle, float aSamplerate );
	public delegate void PFNSOLOUD_SETPANPROC( void* aObjHandle, uint aVoiceHandle, float aPan );
	public delegate void PFNSOLOUD_SETPANABSOLUTEEXPROC( void* aObjHandle, uint aVoiceHandle, float aLVolume, float aRVolume, float aLBVolume, float aRBVolume, float aCVolume, float aSVolume );
	public delegate void PFNSOLOUD_SETVOLUMEPROC( void* aObjHandle, uint aVoiceHandle, float aVolume );
	public delegate void PFNSOLOUD_SETDELAYSAMPLESPROC( void* aObjHandle, uint aVoiceHandle, uint aSamples );
	public delegate void PFNSOLOUD_FADEVOLUMEPROC( void* aObjHandle, uint aVoiceHandle, float aTo, double aTime );
	public delegate void PFNSOLOUD_FADEPANPROC( void* aObjHandle, uint aVoiceHandle, float aTo, double aTime );
	public delegate void PFNSOLOUD_FADERELATIVEPLAYSPEEDPROC( void* aObjHandle, uint aVoiceHandle, float aTo, double aTime );
	public delegate void PFNSOLOUD_FADEGLOBALVOLUMEPROC( void* aObjHandle, float aTo, double aTime );
	public delegate void PFNSOLOUD_SCHEDULEPAUSEPROC( void* aObjHandle, uint aVoiceHandle, double aTime );
	public delegate void PFNSOLOUD_SCHEDULESTOPPROC( void* aObjHandle, uint aVoiceHandle, double aTime );
	public delegate void PFNSOLOUD_OSCILLATEVOLUMEPROC( void* aObjHandle, uint aVoiceHandle, float aFrom, float aTo, double aTime );
	public delegate void PFNSOLOUD_OSCILLATEPANPROC( void* aObjHandle, uint aVoiceHandle, float aFrom, float aTo, double aTime );
	public delegate void PFNSOLOUD_OSCILLATERELATIVEPLAYSPEEDPROC( void* aObjHandle, uint aVoiceHandle, float aFrom, float aTo, double aTime );
	public delegate void PFNSOLOUD_OSCILLATEGLOBALVOLUMEPROC( void* aObjHandle, float aFrom, float aTo, double aTime );
	public delegate void PFNSOLOUD_SETGLOBALFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNSOLOUD_SETVISUALIZATIONENABLEPROC( void* aObjHandle, int aEnable );
	public delegate void* PFNSOLOUD_CALCFFTPROC( void* aObjHandle );
	public delegate void* PFNSOLOUD_GETWAVEPROC( void* aObjHandle );
	public delegate uint PFNSOLOUD_GETLOOPCOUNTPROC( void* aObjHandle, uint aVoiceHandle );
	public delegate float PFNSOLOUD_GETINFOPROC( void* aObjHandle, uint aVoiceHandle, uint aInfoKey );
	public delegate uint PFNSOLOUD_CREATEVOICEGROUPPROC( void* aObjHandle );
	public delegate int PFNSOLOUD_DESTROYVOICEGROUPPROC( void* aObjHandle, uint aVoiceGroupHandle );
	public delegate int PFNSOLOUD_ADDVOICETOGROUPPROC( void* aObjHandle, uint aVoiceGroupHandle, uint aVoiceHandle );
	public delegate int PFNSOLOUD_ISVOICEGROUPPROC( void* aObjHandle, uint aVoiceGroupHandle );
	public delegate int PFNSOLOUD_ISVOICEGROUPEMPTYPROC( void* aObjHandle, uint aVoiceGroupHandle );
	public delegate void PFNSOLOUD_UPDATE3DAUDIOPROC( void* aObjHandle );
	public delegate int PFNSOLOUD_SET3DSOUNDSPEEDPROC( void* aObjHandle, float aSpeed );
	public delegate float PFNSOLOUD_GET3DSOUNDSPEEDPROC( void* aObjHandle );
	public delegate void PFNSOLOUD_SET3DLISTENERPARAMETERSEXPROC( void* aObjHandle, float aPosX, float aPosY, float aPosZ, float aAtX, float aAtY, float aAtZ, float aUpX, float aUpY, float aUpZ, float aVelocityX, float aVelocityY, float aVelocityZ );
	public delegate void PFNSOLOUD_SET3DLISTENERPOSITIONPROC( void* aObjHandle, float aPosX, float aPosY, float aPosZ );
	public delegate void PFNSOLOUD_SET3DLISTENERATPROC( void* aObjHandle, float aAtX, float aAtY, float aAtZ );
	public delegate void PFNSOLOUD_SET3DLISTENERUPPROC( void* aObjHandle, float aUpX, float aUpY, float aUpZ );
	public delegate void PFNSOLOUD_SET3DLISTENERVELOCITYPROC( void* aObjHandle, float aVelocityX, float aVelocityY, float aVelocityZ );
	public delegate void PFNSOLOUD_SET3DSOURCEPARAMETERSEXPROC( void* aObjHandle, uint aVoiceHandle, float aPosX, float aPosY, float aPosZ, float aVelocityX, float aVelocityY, float aVelocityZ );
	public delegate void PFNSOLOUD_SET3DSOURCEPOSITIONPROC( void* aObjHandle, uint aVoiceHandle, float aPosX, float aPosY, float aPosZ );
	public delegate void PFNSOLOUD_SET3DSOURCEVELOCITYPROC( void* aObjHandle, uint aVoiceHandle, float aVelocityX, float aVelocityY, float aVelocityZ );
	public delegate void PFNSOLOUD_SET3DSOURCEMINMAXDISTANCEPROC( void* aObjHandle, uint aVoiceHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNSOLOUD_SET3DSOURCEATTENUATIONPROC( void* aObjHandle, uint aVoiceHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNSOLOUD_SET3DSOURCEDOPPLERFACTORPROC( void* aObjHandle, uint aVoiceHandle, float aDopplerFactor );
	public delegate void PFNSOLOUD_MIXPROC( void* aObjHandle, float[] aBuffer, uint aSamples );
	public delegate void PFNSOLOUD_MIXSIGNED16PROC( void* aObjHandle, void* aBuffer, uint aSamples );
	public delegate void* PFNAUDIOATTENUATOR_DESTROYPROC( void* aObjHandle );
	public delegate float PFNAUDIOATTENUATOR_ATTENUATEPROC( void* aObjHandle, float aDistance, float aMinDistance, float aMaxDistance, float aRolloffFactor );
	public delegate void* PFNBIQUADRESONANTFILTER_CREATEPROC();
	public delegate void* PFNBIQUADRESONANTFILTER_DESTROYPROC( void* aObjHandle );
	public delegate int PFNBIQUADRESONANTFILTER_SETPARAMSPROC( void* aObjHandle, int aType, float aSampleRate, float aFrequency, float aResonance );
	public delegate void* PFNLOFIFILTER_CREATEPROC();
	public delegate void* PFNLOFIFILTER_DESTROYPROC( void* aObjHandle );
	public delegate int PFNLOFIFILTER_SETPARAMSPROC( void* aObjHandle, float aSampleRate, float aBitdepth );
	public delegate void* PFNBUS_CREATEPROC();
	public delegate void* PFNBUS_DESTROYPROC( void* aObjHandle );
	public delegate void PFNBUS_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate uint PFNBUS_PLAYEXPROC( void* aObjHandle, void* aSound, float aVolume, float aPan, int aPaused );
	public delegate uint PFNBUS_PLAYCLOCKEDEXPROC( void* aObjHandle, double aSoundTime, void* aSound, float aVolume, float aPan );
	public delegate uint PFNBUS_PLAY3DEXPROC( void* aObjHandle, void* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume, int aPaused );
	public delegate uint PFNBUS_PLAY3DCLOCKEDEXPROC( void* aObjHandle, double aSoundTime, void* aSound, float aPosX, float aPosY, float aPosZ, float aVelX, float aVelY, float aVelZ, float aVolume );
	public delegate int PFNBUS_SETCHANNELSPROC( void* aObjHandle, uint aChannels );
	public delegate void PFNBUS_SETVISUALIZATIONENABLEPROC( void* aObjHandle, int aEnable );
	public delegate void* PFNBUS_CALCFFTPROC( void* aObjHandle );
	public delegate void* PFNBUS_GETWAVEPROC( void* aObjHandle );
	public delegate void PFNBUS_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNBUS_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNBUS_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNBUS_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNBUS_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNBUS_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNBUS_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNBUS_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNBUS_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNBUS_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNBUS_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNBUS_STOPPROC( void* aObjHandle );
	public delegate void* PFNECHOFILTER_CREATEPROC();
	public delegate void* PFNECHOFILTER_DESTROYPROC( void* aObjHandle );
	public delegate int PFNECHOFILTER_SETPARAMSEXPROC( void* aObjHandle, float aDelay, float aDecay, float aFilter );
	public delegate void* PFNFFTFILTER_CREATEPROC();
	public delegate void* PFNFFTFILTER_DESTROYPROC( void* aObjHandle );
	public delegate void* PFNBASSBOOSTFILTER_CREATEPROC();
	public delegate void* PFNBASSBOOSTFILTER_DESTROYPROC( void* aObjHandle );
	public delegate int PFNBASSBOOSTFILTER_SETPARAMSPROC( void* aObjHandle, float aBoost );
	public delegate void* PFNSPEECH_CREATEPROC();
	public delegate void* PFNSPEECH_DESTROYPROC( void* aObjHandle );
	public delegate int PFNSPEECH_SETTEXTPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aText );
	public delegate void PFNSPEECH_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNSPEECH_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNSPEECH_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNSPEECH_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNSPEECH_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNSPEECH_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNSPEECH_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNSPEECH_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNSPEECH_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNSPEECH_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNSPEECH_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNSPEECH_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNSPEECH_STOPPROC( void* aObjHandle );
	public delegate void* PFNWAV_CREATEPROC();
	public delegate void* PFNWAV_DESTROYPROC( void* aObjHandle );
	public delegate int PFNWAV_LOADPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNWAV_LOADMEMEXPROC( void* aObjHandle, void* aMem, uint aLength, int aCopy, int aTakeOwnership );
	public delegate int PFNWAV_LOADFILEPROC( void* aObjHandle, void* aFile );
	public delegate double PFNWAV_GETLENGTHPROC( void* aObjHandle );
	public delegate void PFNWAV_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNWAV_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNWAV_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNWAV_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNWAV_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNWAV_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNWAV_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNWAV_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNWAV_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNWAV_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNWAV_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNWAV_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNWAV_STOPPROC( void* aObjHandle );
	public delegate void* PFNWAVSTREAM_CREATEPROC();
	public delegate void* PFNWAVSTREAM_DESTROYPROC( void* aObjHandle );
	public delegate int PFNWAVSTREAM_LOADPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNWAVSTREAM_LOADMEMEXPROC( void* aObjHandle, void* aData, uint aDataLen, int aCopy, int aTakeOwnership );
	public delegate int PFNWAVSTREAM_LOADTOMEMPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNWAVSTREAM_LOADFILEPROC( void* aObjHandle, void* aFile );
	public delegate int PFNWAVSTREAM_LOADFILETOMEMPROC( void* aObjHandle, void* aFile );
	public delegate double PFNWAVSTREAM_GETLENGTHPROC( void* aObjHandle );
	public delegate void PFNWAVSTREAM_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNWAVSTREAM_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNWAVSTREAM_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNWAVSTREAM_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNWAVSTREAM_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNWAVSTREAM_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNWAVSTREAM_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNWAVSTREAM_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNWAVSTREAM_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNWAVSTREAM_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNWAVSTREAM_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNWAVSTREAM_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNWAVSTREAM_STOPPROC( void* aObjHandle );
	public delegate void* PFNPRG_CREATEPROC();
	public delegate void* PFNPRG_DESTROYPROC( void* aObjHandle );
	public delegate uint PFNPRG_RANDPROC( void* aObjHandle );
	public delegate void PFNPRG_SRANDPROC( void* aObjHandle, int aSeed );
	public delegate void* PFNSFXR_CREATEPROC();
	public delegate void* PFNSFXR_DESTROYPROC( void* aObjHandle );
	public delegate void PFNSFXR_RESETPARAMSPROC( void* aObjHandle );
	public delegate int PFNSFXR_LOADPARAMSPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNSFXR_LOADPARAMSMEMEXPROC( void* aObjHandle, void* aMem, uint aLength, int aCopy, int aTakeOwnership );
	public delegate int PFNSFXR_LOADPARAMSFILEPROC( void* aObjHandle, void* aFile );
	public delegate int PFNSFXR_LOADPRESETPROC( void* aObjHandle, int aPresetNo, int aRandSeed );
	public delegate void PFNSFXR_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNSFXR_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNSFXR_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNSFXR_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNSFXR_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNSFXR_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNSFXR_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNSFXR_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNSFXR_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNSFXR_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNSFXR_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNSFXR_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNSFXR_STOPPROC( void* aObjHandle );
	public delegate void* PFNFLANGERFILTER_CREATEPROC();
	public delegate void* PFNFLANGERFILTER_DESTROYPROC( void* aObjHandle );
	public delegate int PFNFLANGERFILTER_SETPARAMSPROC( void* aObjHandle, float aDelay, float aFreq );
	public delegate void* PFNDCREMOVALFILTER_CREATEPROC();
	public delegate void* PFNDCREMOVALFILTER_DESTROYPROC( void* aObjHandle );
	public delegate int PFNDCREMOVALFILTER_SETPARAMSEXPROC( void* aObjHandle, float aLength );
	public delegate void* PFNMODPLUG_CREATEPROC();
	public delegate void* PFNMODPLUG_DESTROYPROC( void* aObjHandle );
	public delegate int PFNMODPLUG_LOADPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNMODPLUG_LOADMEMEXPROC( void* aObjHandle, void* aMem, uint aLength, int aCopy, int aTakeOwnership );
	public delegate int PFNMODPLUG_LOADFILEPROC( void* aObjHandle, void* aFile );
	public delegate void PFNMODPLUG_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNMODPLUG_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNMODPLUG_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNMODPLUG_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNMODPLUG_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNMODPLUG_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNMODPLUG_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNMODPLUG_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNMODPLUG_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNMODPLUG_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNMODPLUG_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNMODPLUG_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNMODPLUG_STOPPROC( void* aObjHandle );
	public delegate void* PFNMONOTONE_CREATEPROC();
	public delegate void* PFNMONOTONE_DESTROYPROC( void* aObjHandle );
	public delegate int PFNMONOTONE_SETPARAMSEXPROC( void* aObjHandle, int aHardwareChannels, int aWaveform );
	public delegate int PFNMONOTONE_LOADPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNMONOTONE_LOADMEMEXPROC( void* aObjHandle, void* aMem, uint aLength, int aCopy, int aTakeOwnership );
	public delegate int PFNMONOTONE_LOADFILEPROC( void* aObjHandle, void* aFile );
	public delegate void PFNMONOTONE_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNMONOTONE_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNMONOTONE_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNMONOTONE_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNMONOTONE_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNMONOTONE_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNMONOTONE_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNMONOTONE_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNMONOTONE_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNMONOTONE_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNMONOTONE_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNMONOTONE_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNMONOTONE_STOPPROC( void* aObjHandle );
	public delegate void* PFNTEDSID_CREATEPROC();
	public delegate void* PFNTEDSID_DESTROYPROC( void* aObjHandle );
	public delegate int PFNTEDSID_LOADPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNTEDSID_LOADTOMEMPROC( void* aObjHandle, [MarshalAs( UnmanagedType.LPStr )] string aFilename );
	public delegate int PFNTEDSID_LOADMEMEXPROC( void* aObjHandle, void* aMem, uint aLength, int aCopy, int aTakeOwnership );
	public delegate int PFNTEDSID_LOADFILETOMEMPROC( void* aObjHandle, void* aFile );
	public delegate int PFNTEDSID_LOADFILEPROC( void* aObjHandle, void* aFile );
	public delegate void PFNTEDSID_SETVOLUMEPROC( void* aObjHandle, float aVolume );
	public delegate void PFNTEDSID_SETLOOPINGPROC( void* aObjHandle, int aLoop );
	public delegate void PFNTEDSID_SET3DMINMAXDISTANCEPROC( void* aObjHandle, float aMinDistance, float aMaxDistance );
	public delegate void PFNTEDSID_SET3DATTENUATIONPROC( void* aObjHandle, uint aAttenuationModel, float aAttenuationRolloffFactor );
	public delegate void PFNTEDSID_SET3DDOPPLERFACTORPROC( void* aObjHandle, float aDopplerFactor );
	public delegate void PFNTEDSID_SET3DPROCESSINGPROC( void* aObjHandle, int aDo3dProcessing );
	public delegate void PFNTEDSID_SET3DLISTENERRELATIVEPROC( void* aObjHandle, int aListenerRelative );
	public delegate void PFNTEDSID_SET3DDISTANCEDELAYPROC( void* aObjHandle, int aDistanceDelay );
	public delegate void PFNTEDSID_SET3DCOLLIDEREXPROC( void* aObjHandle, void* aCollider, int aUserData );
	public delegate void PFNTEDSID_SET3DATTENUATORPROC( void* aObjHandle, void* aAttenuator );
	public delegate void PFNTEDSID_SETINAUDIBLEBEHAVIORPROC( void* aObjHandle, int aMustTick, int aKill );
	public delegate void PFNTEDSID_SETFILTERPROC( void* aObjHandle, uint aFilterId, void* aFilter );
	public delegate void PFNTEDSID_STOPPROC( void* aObjHandle );
	#endregion

	#region Methods
	[ExternalMethod]
	public static PFNSOLOUD_CREATEPROC Soloud_create;
	[ExternalMethod]
	public static PFNSOLOUD_DESTROYPROC Soloud_destroy;
	[ExternalMethod]
	public static PFNSOLOUD_INITEXPROC Soloud_initEx;
	[ExternalMethod]
	public static PFNSOLOUD_DEINITPROC Soloud_deinit;
	[ExternalMethod]
	public static PFNSOLOUD_GETVERSIONPROC Soloud_getVersion;
	[ExternalMethod]
	public static PFNSOLOUD_GETERRORSTRINGPROC Soloud_getErrorString;
	[ExternalMethod]
	public static PFNSOLOUD_GETBACKENDIDPROC Soloud_getBackendId;
	[ExternalMethod]
	public static PFNSOLOUD_GETBACKENDSTRINGPROC Soloud_getBackendString;
	[ExternalMethod]
	public static PFNSOLOUD_GETBACKENDCHANNELSPROC Soloud_getBackendChannels;
	[ExternalMethod]
	public static PFNSOLOUD_GETBACKENDSAMPLERATEPROC Soloud_getBackendSamplerate;
	[ExternalMethod]
	public static PFNSOLOUD_GETBACKENDBUFFERSIZEPROC Soloud_getBackendBufferSize;
	[ExternalMethod]
	public static PFNSOLOUD_SETSPEAKERPOSITIONPROC Soloud_setSpeakerPosition;
	[ExternalMethod]
	public static PFNSOLOUD_PLAYEXPROC Soloud_playEx;
	[ExternalMethod]
	public static PFNSOLOUD_PLAYCLOCKEDEXPROC Soloud_playClockedEx;
	[ExternalMethod]
	public static PFNSOLOUD_PLAY3DEXPROC Soloud_play3dEx;
	[ExternalMethod]
	public static PFNSOLOUD_PLAY3DCLOCKEDEXPROC Soloud_play3dClockedEx;
	[ExternalMethod]
	public static PFNSOLOUD_SEEKPROC Soloud_seek;
	[ExternalMethod]
	public static PFNSOLOUD_STOPPROC Soloud_stop;
	[ExternalMethod]
	public static PFNSOLOUD_STOPALLPROC Soloud_stopAll;
	[ExternalMethod]
	public static PFNSOLOUD_STOPAUDIOSOURCEPROC Soloud_stopAudioSource;
	[ExternalMethod]
	public static PFNSOLOUD_SETFILTERPARAMETERPROC Soloud_setFilterParameter;
	[ExternalMethod]
	public static PFNSOLOUD_GETFILTERPARAMETERPROC Soloud_getFilterParameter;
	[ExternalMethod]
	public static PFNSOLOUD_FADEFILTERPARAMETERPROC Soloud_fadeFilterParameter;
	[ExternalMethod]
	public static PFNSOLOUD_OSCILLATEFILTERPARAMETERPROC Soloud_oscillateFilterParameter;
	[ExternalMethod]
	public static PFNSOLOUD_GETSTREAMTIMEPROC Soloud_getStreamTime;
	[ExternalMethod]
	public static PFNSOLOUD_GETPAUSEPROC Soloud_getPause;
	[ExternalMethod]
	public static PFNSOLOUD_GETVOLUMEPROC Soloud_getVolume;
	[ExternalMethod]
	public static PFNSOLOUD_GETOVERALLVOLUMEPROC Soloud_getOverallVolume;
	[ExternalMethod]
	public static PFNSOLOUD_GETPANPROC Soloud_getPan;
	[ExternalMethod]
	public static PFNSOLOUD_GETSAMPLERATEPROC Soloud_getSamplerate;
	[ExternalMethod]
	public static PFNSOLOUD_GETPROTECTVOICEPROC Soloud_getProtectVoice;
	[ExternalMethod]
	public static PFNSOLOUD_GETACTIVEVOICECOUNTPROC Soloud_getActiveVoiceCount;
	[ExternalMethod]
	public static PFNSOLOUD_GETVOICECOUNTPROC Soloud_getVoiceCount;
	[ExternalMethod]
	public static PFNSOLOUD_ISVALIDVOICEHANDLEPROC Soloud_isValidVoiceHandle;
	[ExternalMethod]
	public static PFNSOLOUD_GETRELATIVEPLAYSPEEDPROC Soloud_getRelativePlaySpeed;
	[ExternalMethod]
	public static PFNSOLOUD_GETPOSTCLIPSCALERPROC Soloud_getPostClipScaler;
	[ExternalMethod]
	public static PFNSOLOUD_GETGLOBALVOLUMEPROC Soloud_getGlobalVolume;
	[ExternalMethod]
	public static PFNSOLOUD_GETMAXACTIVEVOICECOUNTPROC Soloud_getMaxActiveVoiceCount;
	[ExternalMethod]
	public static PFNSOLOUD_GETLOOPINGPROC Soloud_getLooping;
	[ExternalMethod]
	public static PFNSOLOUD_SETLOOPINGPROC Soloud_setLooping;
	[ExternalMethod]
	public static PFNSOLOUD_SETMAXACTIVEVOICECOUNTPROC Soloud_setMaxActiveVoiceCount;
	[ExternalMethod]
	public static PFNSOLOUD_SETINAUDIBLEBEHAVIORPROC Soloud_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNSOLOUD_SETGLOBALVOLUMEPROC Soloud_setGlobalVolume;
	[ExternalMethod]
	public static PFNSOLOUD_SETPOSTCLIPSCALERPROC Soloud_setPostClipScaler;
	[ExternalMethod]
	public static PFNSOLOUD_SETPAUSEPROC Soloud_setPause;
	[ExternalMethod]
	public static PFNSOLOUD_SETPAUSEALLPROC Soloud_setPauseAll;
	[ExternalMethod]
	public static PFNSOLOUD_SETRELATIVEPLAYSPEEDPROC Soloud_setRelativePlaySpeed;
	[ExternalMethod]
	public static PFNSOLOUD_SETPROTECTVOICEPROC Soloud_setProtectVoice;
	[ExternalMethod]
	public static PFNSOLOUD_SETSAMPLERATEPROC Soloud_setSamplerate;
	[ExternalMethod]
	public static PFNSOLOUD_SETPANPROC Soloud_setPan;
	[ExternalMethod]
	public static PFNSOLOUD_SETPANABSOLUTEEXPROC Soloud_setPanAbsoluteEx;
	[ExternalMethod]
	public static PFNSOLOUD_SETVOLUMEPROC Soloud_setVolume;
	[ExternalMethod]
	public static PFNSOLOUD_SETDELAYSAMPLESPROC Soloud_setDelaySamples;
	[ExternalMethod]
	public static PFNSOLOUD_FADEVOLUMEPROC Soloud_fadeVolume;
	[ExternalMethod]
	public static PFNSOLOUD_FADEPANPROC Soloud_fadePan;
	[ExternalMethod]
	public static PFNSOLOUD_FADERELATIVEPLAYSPEEDPROC Soloud_fadeRelativePlaySpeed;
	[ExternalMethod]
	public static PFNSOLOUD_FADEGLOBALVOLUMEPROC Soloud_fadeGlobalVolume;
	[ExternalMethod]
	public static PFNSOLOUD_SCHEDULEPAUSEPROC Soloud_schedulePause;
	[ExternalMethod]
	public static PFNSOLOUD_SCHEDULESTOPPROC Soloud_scheduleStop;
	[ExternalMethod]
	public static PFNSOLOUD_OSCILLATEVOLUMEPROC Soloud_oscillateVolume;
	[ExternalMethod]
	public static PFNSOLOUD_OSCILLATEPANPROC Soloud_oscillatePan;
	[ExternalMethod]
	public static PFNSOLOUD_OSCILLATERELATIVEPLAYSPEEDPROC Soloud_oscillateRelativePlaySpeed;
	[ExternalMethod]
	public static PFNSOLOUD_OSCILLATEGLOBALVOLUMEPROC Soloud_oscillateGlobalVolume;
	[ExternalMethod]
	public static PFNSOLOUD_SETGLOBALFILTERPROC Soloud_setGlobalFilter;
	[ExternalMethod]
	public static PFNSOLOUD_SETVISUALIZATIONENABLEPROC Soloud_setVisualizationEnable;
	[ExternalMethod]
	public static PFNSOLOUD_CALCFFTPROC Soloud_calcFFT;
	[ExternalMethod]
	public static PFNSOLOUD_GETWAVEPROC Soloud_getWave;
	[ExternalMethod]
	public static PFNSOLOUD_GETLOOPCOUNTPROC Soloud_getLoopCount;
	[ExternalMethod]
	public static PFNSOLOUD_GETINFOPROC Soloud_getInfo;
	[ExternalMethod]
	public static PFNSOLOUD_CREATEVOICEGROUPPROC Soloud_createVoiceGroup;
	[ExternalMethod]
	public static PFNSOLOUD_DESTROYVOICEGROUPPROC Soloud_destroyVoiceGroup;
	[ExternalMethod]
	public static PFNSOLOUD_ADDVOICETOGROUPPROC Soloud_addVoiceToGroup;
	[ExternalMethod]
	public static PFNSOLOUD_ISVOICEGROUPPROC Soloud_isVoiceGroup;
	[ExternalMethod]
	public static PFNSOLOUD_ISVOICEGROUPEMPTYPROC Soloud_isVoiceGroupEmpty;
	[ExternalMethod]
	public static PFNSOLOUD_UPDATE3DAUDIOPROC Soloud_update3dAudio;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DSOUNDSPEEDPROC Soloud_set3dSoundSpeed;
	[ExternalMethod]
	public static PFNSOLOUD_GET3DSOUNDSPEEDPROC Soloud_get3dSoundSpeed;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DLISTENERPARAMETERSEXPROC Soloud_set3dListenerParametersEx;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DLISTENERPOSITIONPROC Soloud_set3dListenerPosition;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DLISTENERATPROC Soloud_set3dListenerAt;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DLISTENERUPPROC Soloud_set3dListenerUp;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DLISTENERVELOCITYPROC Soloud_set3dListenerVelocity;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DSOURCEPARAMETERSEXPROC Soloud_set3dSourceParametersEx;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DSOURCEPOSITIONPROC Soloud_set3dSourcePosition;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DSOURCEVELOCITYPROC Soloud_set3dSourceVelocity;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DSOURCEMINMAXDISTANCEPROC Soloud_set3dSourceMinMaxDistance;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DSOURCEATTENUATIONPROC Soloud_set3dSourceAttenuation;
	[ExternalMethod]
	public static PFNSOLOUD_SET3DSOURCEDOPPLERFACTORPROC Soloud_set3dSourceDopplerFactor;
	[ExternalMethod]
	public static PFNSOLOUD_MIXPROC Soloud_mix;
	[ExternalMethod]
	public static PFNSOLOUD_MIXSIGNED16PROC Soloud_mixSigned16;
	[ExternalMethod]
	public static PFNAUDIOATTENUATOR_DESTROYPROC AudioAttenuator_destroy;
	[ExternalMethod]
	public static PFNAUDIOATTENUATOR_ATTENUATEPROC AudioAttenuator_attenuate;
	[ExternalMethod]
	public static PFNBIQUADRESONANTFILTER_CREATEPROC BiquadResonantFilter_create;
	[ExternalMethod]
	public static PFNBIQUADRESONANTFILTER_DESTROYPROC BiquadResonantFilter_destroy;
	[ExternalMethod]
	public static PFNBIQUADRESONANTFILTER_SETPARAMSPROC BiquadResonantFilter_setParams;
	[ExternalMethod]
	public static PFNLOFIFILTER_CREATEPROC LofiFilter_create;
	[ExternalMethod]
	public static PFNLOFIFILTER_DESTROYPROC LofiFilter_destroy;
	[ExternalMethod]
	public static PFNLOFIFILTER_SETPARAMSPROC LofiFilter_setParams;
	[ExternalMethod]
	public static PFNBUS_CREATEPROC Bus_create;
	[ExternalMethod]
	public static PFNBUS_DESTROYPROC Bus_destroy;
	[ExternalMethod]
	public static PFNBUS_SETFILTERPROC Bus_setFilter;
	[ExternalMethod]
	public static PFNBUS_PLAYEXPROC Bus_playEx;
	[ExternalMethod]
	public static PFNBUS_PLAYCLOCKEDEXPROC Bus_playClockedEx;
	[ExternalMethod]
	public static PFNBUS_PLAY3DEXPROC Bus_play3dEx;
	[ExternalMethod]
	public static PFNBUS_PLAY3DCLOCKEDEXPROC Bus_play3dClockedEx;
	[ExternalMethod]
	public static PFNBUS_SETCHANNELSPROC Bus_setChannels;
	[ExternalMethod]
	public static PFNBUS_SETVISUALIZATIONENABLEPROC Bus_setVisualizationEnable;
	[ExternalMethod]
	public static PFNBUS_CALCFFTPROC Bus_calcFFT;
	[ExternalMethod]
	public static PFNBUS_GETWAVEPROC Bus_getWave;
	[ExternalMethod]
	public static PFNBUS_SETVOLUMEPROC Bus_setVolume;
	[ExternalMethod]
	public static PFNBUS_SETLOOPINGPROC Bus_setLooping;
	[ExternalMethod]
	public static PFNBUS_SET3DMINMAXDISTANCEPROC Bus_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNBUS_SET3DATTENUATIONPROC Bus_set3dAttenuation;
	[ExternalMethod]
	public static PFNBUS_SET3DDOPPLERFACTORPROC Bus_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNBUS_SET3DPROCESSINGPROC Bus_set3dProcessing;
	[ExternalMethod]
	public static PFNBUS_SET3DLISTENERRELATIVEPROC Bus_set3dListenerRelative;
	[ExternalMethod]
	public static PFNBUS_SET3DDISTANCEDELAYPROC Bus_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNBUS_SET3DCOLLIDEREXPROC Bus_set3dColliderEx;
	[ExternalMethod]
	public static PFNBUS_SET3DATTENUATORPROC Bus_set3dAttenuator;
	[ExternalMethod]
	public static PFNBUS_SETINAUDIBLEBEHAVIORPROC Bus_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNBUS_STOPPROC Bus_stop;
	[ExternalMethod]
	public static PFNECHOFILTER_CREATEPROC EchoFilter_create;
	[ExternalMethod]
	public static PFNECHOFILTER_DESTROYPROC EchoFilter_destroy;
	[ExternalMethod]
	public static PFNECHOFILTER_SETPARAMSEXPROC EchoFilter_setParamsEx;
	[ExternalMethod]
	public static PFNFFTFILTER_CREATEPROC FFTFilter_create;
	[ExternalMethod]
	public static PFNFFTFILTER_DESTROYPROC FFTFilter_destroy;
	[ExternalMethod]
	public static PFNBASSBOOSTFILTER_CREATEPROC BassboostFilter_create;
	[ExternalMethod]
	public static PFNBASSBOOSTFILTER_DESTROYPROC BassboostFilter_destroy;
	[ExternalMethod]
	public static PFNBASSBOOSTFILTER_SETPARAMSPROC BassboostFilter_setParams;
	[ExternalMethod]
	public static PFNSPEECH_CREATEPROC Speech_create;
	[ExternalMethod]
	public static PFNSPEECH_DESTROYPROC Speech_destroy;
	[ExternalMethod]
	public static PFNSPEECH_SETTEXTPROC Speech_setText;
	[ExternalMethod]
	public static PFNSPEECH_SETVOLUMEPROC Speech_setVolume;
	[ExternalMethod]
	public static PFNSPEECH_SETLOOPINGPROC Speech_setLooping;
	[ExternalMethod]
	public static PFNSPEECH_SET3DMINMAXDISTANCEPROC Speech_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNSPEECH_SET3DATTENUATIONPROC Speech_set3dAttenuation;
	[ExternalMethod]
	public static PFNSPEECH_SET3DDOPPLERFACTORPROC Speech_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNSPEECH_SET3DPROCESSINGPROC Speech_set3dProcessing;
	[ExternalMethod]
	public static PFNSPEECH_SET3DLISTENERRELATIVEPROC Speech_set3dListenerRelative;
	[ExternalMethod]
	public static PFNSPEECH_SET3DDISTANCEDELAYPROC Speech_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNSPEECH_SET3DCOLLIDEREXPROC Speech_set3dColliderEx;
	[ExternalMethod]
	public static PFNSPEECH_SET3DATTENUATORPROC Speech_set3dAttenuator;
	[ExternalMethod]
	public static PFNSPEECH_SETINAUDIBLEBEHAVIORPROC Speech_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNSPEECH_SETFILTERPROC Speech_setFilter;
	[ExternalMethod]
	public static PFNSPEECH_STOPPROC Speech_stop;
	[ExternalMethod]
	public static PFNWAV_CREATEPROC Wav_create;
	[ExternalMethod]
	public static PFNWAV_DESTROYPROC Wav_destroy;
	[ExternalMethod]
	public static PFNWAV_LOADPROC Wav_load;
	[ExternalMethod]
	public static PFNWAV_LOADMEMEXPROC Wav_loadMemEx;
	[ExternalMethod]
	public static PFNWAV_LOADFILEPROC Wav_loadFile;
	[ExternalMethod]
	public static PFNWAV_GETLENGTHPROC Wav_getLength;
	[ExternalMethod]
	public static PFNWAV_SETVOLUMEPROC Wav_setVolume;
	[ExternalMethod]
	public static PFNWAV_SETLOOPINGPROC Wav_setLooping;
	[ExternalMethod]
	public static PFNWAV_SET3DMINMAXDISTANCEPROC Wav_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNWAV_SET3DATTENUATIONPROC Wav_set3dAttenuation;
	[ExternalMethod]
	public static PFNWAV_SET3DDOPPLERFACTORPROC Wav_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNWAV_SET3DPROCESSINGPROC Wav_set3dProcessing;
	[ExternalMethod]
	public static PFNWAV_SET3DLISTENERRELATIVEPROC Wav_set3dListenerRelative;
	[ExternalMethod]
	public static PFNWAV_SET3DDISTANCEDELAYPROC Wav_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNWAV_SET3DCOLLIDEREXPROC Wav_set3dColliderEx;
	[ExternalMethod]
	public static PFNWAV_SET3DATTENUATORPROC Wav_set3dAttenuator;
	[ExternalMethod]
	public static PFNWAV_SETINAUDIBLEBEHAVIORPROC Wav_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNWAV_SETFILTERPROC Wav_setFilter;
	[ExternalMethod]
	public static PFNWAV_STOPPROC Wav_stop;
	[ExternalMethod]
	public static PFNWAVSTREAM_CREATEPROC WavStream_create;
	[ExternalMethod]
	public static PFNWAVSTREAM_DESTROYPROC WavStream_destroy;
	[ExternalMethod]
	public static PFNWAVSTREAM_LOADPROC WavStream_load;
	[ExternalMethod]
	public static PFNWAVSTREAM_LOADMEMEXPROC WavStream_loadMemEx;
	[ExternalMethod]
	public static PFNWAVSTREAM_LOADTOMEMPROC WavStream_loadToMem;
	[ExternalMethod]
	public static PFNWAVSTREAM_LOADFILEPROC WavStream_loadFile;
	[ExternalMethod]
	public static PFNWAVSTREAM_LOADFILETOMEMPROC WavStream_loadFileToMem;
	[ExternalMethod]
	public static PFNWAVSTREAM_GETLENGTHPROC WavStream_getLength;
	[ExternalMethod]
	public static PFNWAVSTREAM_SETVOLUMEPROC WavStream_setVolume;
	[ExternalMethod]
	public static PFNWAVSTREAM_SETLOOPINGPROC WavStream_setLooping;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DMINMAXDISTANCEPROC WavStream_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DATTENUATIONPROC WavStream_set3dAttenuation;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DDOPPLERFACTORPROC WavStream_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DPROCESSINGPROC WavStream_set3dProcessing;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DLISTENERRELATIVEPROC WavStream_set3dListenerRelative;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DDISTANCEDELAYPROC WavStream_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DCOLLIDEREXPROC WavStream_set3dColliderEx;
	[ExternalMethod]
	public static PFNWAVSTREAM_SET3DATTENUATORPROC WavStream_set3dAttenuator;
	[ExternalMethod]
	public static PFNWAVSTREAM_SETINAUDIBLEBEHAVIORPROC WavStream_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNWAVSTREAM_SETFILTERPROC WavStream_setFilter;
	[ExternalMethod]
	public static PFNWAVSTREAM_STOPPROC WavStream_stop;
	[ExternalMethod]
	public static PFNPRG_CREATEPROC Prg_create;
	[ExternalMethod]
	public static PFNPRG_DESTROYPROC Prg_destroy;
	[ExternalMethod]
	public static PFNPRG_RANDPROC Prg_rand;
	[ExternalMethod]
	public static PFNPRG_SRANDPROC Prg_srand;
	[ExternalMethod]
	public static PFNSFXR_CREATEPROC Sfxr_create;
	[ExternalMethod]
	public static PFNSFXR_DESTROYPROC Sfxr_destroy;
	[ExternalMethod]
	public static PFNSFXR_RESETPARAMSPROC Sfxr_resetParams;
	[ExternalMethod]
	public static PFNSFXR_LOADPARAMSPROC Sfxr_loadParams;
	[ExternalMethod]
	public static PFNSFXR_LOADPARAMSMEMEXPROC Sfxr_loadParamsMemEx;
	[ExternalMethod]
	public static PFNSFXR_LOADPARAMSFILEPROC Sfxr_loadParamsFile;
	[ExternalMethod]
	public static PFNSFXR_LOADPRESETPROC Sfxr_loadPreset;
	[ExternalMethod]
	public static PFNSFXR_SETVOLUMEPROC Sfxr_setVolume;
	[ExternalMethod]
	public static PFNSFXR_SETLOOPINGPROC Sfxr_setLooping;
	[ExternalMethod]
	public static PFNSFXR_SET3DMINMAXDISTANCEPROC Sfxr_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNSFXR_SET3DATTENUATIONPROC Sfxr_set3dAttenuation;
	[ExternalMethod]
	public static PFNSFXR_SET3DDOPPLERFACTORPROC Sfxr_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNSFXR_SET3DPROCESSINGPROC Sfxr_set3dProcessing;
	[ExternalMethod]
	public static PFNSFXR_SET3DLISTENERRELATIVEPROC Sfxr_set3dListenerRelative;
	[ExternalMethod]
	public static PFNSFXR_SET3DDISTANCEDELAYPROC Sfxr_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNSFXR_SET3DCOLLIDEREXPROC Sfxr_set3dColliderEx;
	[ExternalMethod]
	public static PFNSFXR_SET3DATTENUATORPROC Sfxr_set3dAttenuator;
	[ExternalMethod]
	public static PFNSFXR_SETINAUDIBLEBEHAVIORPROC Sfxr_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNSFXR_SETFILTERPROC Sfxr_setFilter;
	[ExternalMethod]
	public static PFNSFXR_STOPPROC Sfxr_stop;
	[ExternalMethod]
	public static PFNFLANGERFILTER_CREATEPROC FlangerFilter_create;
	[ExternalMethod]
	public static PFNFLANGERFILTER_DESTROYPROC FlangerFilter_destroy;
	[ExternalMethod]
	public static PFNFLANGERFILTER_SETPARAMSPROC FlangerFilter_setParams;
	[ExternalMethod]
	public static PFNDCREMOVALFILTER_CREATEPROC DCRemovalFilter_create;
	[ExternalMethod]
	public static PFNDCREMOVALFILTER_DESTROYPROC DCRemovalFilter_destroy;
	[ExternalMethod]
	public static PFNDCREMOVALFILTER_SETPARAMSEXPROC DCRemovalFilter_setParamsEx;
	[ExternalMethod]
	public static PFNMODPLUG_CREATEPROC Modplug_create;
	[ExternalMethod]
	public static PFNMODPLUG_DESTROYPROC Modplug_destroy;
	[ExternalMethod]
	public static PFNMODPLUG_LOADPROC Modplug_load;
	[ExternalMethod]
	public static PFNMODPLUG_LOADMEMEXPROC Modplug_loadMemEx;
	[ExternalMethod]
	public static PFNMODPLUG_LOADFILEPROC Modplug_loadFile;
	[ExternalMethod]
	public static PFNMODPLUG_SETVOLUMEPROC Modplug_setVolume;
	[ExternalMethod]
	public static PFNMODPLUG_SETLOOPINGPROC Modplug_setLooping;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DMINMAXDISTANCEPROC Modplug_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DATTENUATIONPROC Modplug_set3dAttenuation;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DDOPPLERFACTORPROC Modplug_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DPROCESSINGPROC Modplug_set3dProcessing;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DLISTENERRELATIVEPROC Modplug_set3dListenerRelative;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DDISTANCEDELAYPROC Modplug_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DCOLLIDEREXPROC Modplug_set3dColliderEx;
	[ExternalMethod]
	public static PFNMODPLUG_SET3DATTENUATORPROC Modplug_set3dAttenuator;
	[ExternalMethod]
	public static PFNMODPLUG_SETINAUDIBLEBEHAVIORPROC Modplug_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNMODPLUG_SETFILTERPROC Modplug_setFilter;
	[ExternalMethod]
	public static PFNMODPLUG_STOPPROC Modplug_stop;
	[ExternalMethod]
	public static PFNMONOTONE_CREATEPROC Monotone_create;
	[ExternalMethod]
	public static PFNMONOTONE_DESTROYPROC Monotone_destroy;
	[ExternalMethod]
	public static PFNMONOTONE_SETPARAMSEXPROC Monotone_setParamsEx;
	[ExternalMethod]
	public static PFNMONOTONE_LOADPROC Monotone_load;
	[ExternalMethod]
	public static PFNMONOTONE_LOADMEMEXPROC Monotone_loadMemEx;
	[ExternalMethod]
	public static PFNMONOTONE_LOADFILEPROC Monotone_loadFile;
	[ExternalMethod]
	public static PFNMONOTONE_SETVOLUMEPROC Monotone_setVolume;
	[ExternalMethod]
	public static PFNMONOTONE_SETLOOPINGPROC Monotone_setLooping;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DMINMAXDISTANCEPROC Monotone_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DATTENUATIONPROC Monotone_set3dAttenuation;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DDOPPLERFACTORPROC Monotone_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DPROCESSINGPROC Monotone_set3dProcessing;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DLISTENERRELATIVEPROC Monotone_set3dListenerRelative;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DDISTANCEDELAYPROC Monotone_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DCOLLIDEREXPROC Monotone_set3dColliderEx;
	[ExternalMethod]
	public static PFNMONOTONE_SET3DATTENUATORPROC Monotone_set3dAttenuator;
	[ExternalMethod]
	public static PFNMONOTONE_SETINAUDIBLEBEHAVIORPROC Monotone_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNMONOTONE_SETFILTERPROC Monotone_setFilter;
	[ExternalMethod]
	public static PFNMONOTONE_STOPPROC Monotone_stop;
	[ExternalMethod]
	public static PFNTEDSID_CREATEPROC TedSid_create;
	[ExternalMethod]
	public static PFNTEDSID_DESTROYPROC TedSid_destroy;
	[ExternalMethod]
	public static PFNTEDSID_LOADPROC TedSid_load;
	[ExternalMethod]
	public static PFNTEDSID_LOADTOMEMPROC TedSid_loadToMem;
	[ExternalMethod]
	public static PFNTEDSID_LOADMEMEXPROC TedSid_loadMemEx;
	[ExternalMethod]
	public static PFNTEDSID_LOADFILETOMEMPROC TedSid_loadFileToMem;
	[ExternalMethod]
	public static PFNTEDSID_LOADFILEPROC TedSid_loadFile;
	[ExternalMethod]
	public static PFNTEDSID_SETVOLUMEPROC TedSid_setVolume;
	[ExternalMethod]
	public static PFNTEDSID_SETLOOPINGPROC TedSid_setLooping;
	[ExternalMethod]
	public static PFNTEDSID_SET3DMINMAXDISTANCEPROC TedSid_set3dMinMaxDistance;
	[ExternalMethod]
	public static PFNTEDSID_SET3DATTENUATIONPROC TedSid_set3dAttenuation;
	[ExternalMethod]
	public static PFNTEDSID_SET3DDOPPLERFACTORPROC TedSid_set3dDopplerFactor;
	[ExternalMethod]
	public static PFNTEDSID_SET3DPROCESSINGPROC TedSid_set3dProcessing;
	[ExternalMethod]
	public static PFNTEDSID_SET3DLISTENERRELATIVEPROC TedSid_set3dListenerRelative;
	[ExternalMethod]
	public static PFNTEDSID_SET3DDISTANCEDELAYPROC TedSid_set3dDistanceDelay;
	[ExternalMethod]
	public static PFNTEDSID_SET3DCOLLIDEREXPROC TedSid_set3dColliderEx;
	[ExternalMethod]
	public static PFNTEDSID_SET3DATTENUATORPROC TedSid_set3dAttenuator;
	[ExternalMethod]
	public static PFNTEDSID_SETINAUDIBLEBEHAVIORPROC TedSid_setInaudibleBehavior;
	[ExternalMethod]
	public static PFNTEDSID_SETFILTERPROC TedSid_setFilter;
	[ExternalMethod]
	public static PFNTEDSID_STOPPROC TedSid_stop;
	#endregion
}