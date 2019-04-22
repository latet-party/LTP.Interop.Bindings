#define LZ4HC_WRAPPER_IMPLEMENTATION

#region License
/*
	LZ4 Library
	Copyright (c) 2011-2016, Yann Collet
	All rights reserved.

	Redistribution and use in source and binary forms, with or without modification,
	are permitted provided that the following conditions are met:

	* Redistributions of source code must retain the above copyright notice, this
	  list of conditions and the following disclaimer.

	* Redistributions in binary form must reproduce the above copyright notice, this
	  list of conditions and the following disclaimer in the documentation and/or
	  other materials provided with the distribution.

	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
	ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
	WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
	ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
	(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
	LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
	ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
	(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
	SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

#region Using statements
using System;

using LTP.Interop.InteropServices;
#endregion

[Library( "lz4" )]
public static unsafe class LZ4
{
    #region Fields / Properties
    private static IntPtr _handle;
    #endregion

    #region Constants
    public const int LZ4_VERSION_MAJOR = 1;
    public const int LZ4_VERSION_MINOR = 8;
    public const int LZ4_VERSION_RELEASE = 2;
    public const int LZ4_VERSION_NUMBER = ( LZ4_VERSION_MAJOR * ( 100 * ( 100 + ( LZ4_VERSION_MINOR * ( 100 + LZ4_VERSION_RELEASE ) ) ) ) );
    public const int LZ4_MEMORY_USAGE = 14;
    public const int LZ4_MAX_INPUT_SIZE = 2113929216;
    public const int LZ4_HASHLOG = ( LZ4_MEMORY_USAGE - 2 );
    public const int LZ4_HASHTABLESIZE = ( 1 ) << ( LZ4_MEMORY_USAGE );
    public const int LZ4_HASH_SIZE_U32 = ( 1 ) << ( LZ4_HASHLOG );
    public const int LZ4_STREAMSIZE_U64 = ( ( 1 ) << ( ( LZ4_MEMORY_USAGE - 3 ) ) + 4 );
    public const int LZ4_STREAMDECODESIZE_U64 = 4;

#if LZ4HC_WRAPPER_IMPLEMENTATION
    public const int LZ4HC_CLEVEL_MIN = 3;
    public const int LZ4HC_CLEVEL_DEFAULT = 9;
    public const int LZ4HC_CLEVEL_OPT_MIN = 10;
    public const int LZ4HC_CLEVEL_MAX = 12;
    public const int LZ4HC_DICTIONARY_LOGSIZE = 16;
    public const int LZ4HC_MAXD = ( 1 ) << ( LZ4HC_DICTIONARY_LOGSIZE );
    public const int LZ4HC_MAXD_MASK = ( LZ4HC_MAXD - 1 );
    public const int LZ4HC_HASH_LOG = 15;
    public const int LZ4HC_HASHTABLESIZE = ( 1 ) << ( LZ4HC_HASH_LOG );
    public const int LZ4HC_HASH_MASK = ( LZ4HC_HASHTABLESIZE - 1 );
#endif
    #endregion

    #region Delegates
    public delegate int PFNLZ4_VERSIONNUMBERPROC();
    public delegate byte* PFNLZ4_VERSIONSTRINGPROC();
    public delegate int PFNLZ4_COMPRESS_DEFAULTPROC( void* src, void* dst, int srcSize, int dstCapacity );
    public delegate int PFNLZ4_DECOMPRESS_SAFEPROC( void* src, void* dst, int compressedSize, int dstCapacity );
    public delegate int PFNLZ4_COMPRESSBOUNDPROC( int inputSize );
    public delegate int PFNLZ4_COMPRESS_FASTPROC( void* src, void* dst, int srcSize, int dstCapacity, int acceleration );
    public delegate int PFNLZ4_SIZEOFSTATEPROC();
    public delegate int PFNLZ4_COMPRESS_FAST_EXTSTATEPROC( void* state, void* src, void* dst, int srcSize, int dstCapacity, int acceleration );
    public delegate int PFNLZ4_COMPRESS_DESTSIZEPROC( void* src, void* dst, ref int srcSizePtr, int targetDstSize );
    public delegate int PFNLZ4_DECOMPRESS_FASTPROC( void* src, void* dst, int originalSize );
    public delegate int PFNLZ4_DECOMPRESS_SAFE_PARTIALPROC( void* src, void* dst, int srcSize, int targetOutputSize, int dstCapacity );
    public delegate int PFNLZ4_DECODERRINGBUFFERSIZEPROC( int maxBlockSize );
    public delegate int PFNLZ4_DECOMPRESS_SAFE_USINGDICTPROC( void* src, void* dst, int srcSize, int dstCapcity, void* dictStart, int dictSize );
    public delegate int PFNLZ4_DECOMPRESS_FAST_USINGDICTPROC( void* src, void* dst, int originalSize, void* dictStart, int dictSize );

#if LZ4HC_WRAPPER_IMPLEMENTATION
    public delegate int PFNLZ4_COMPRESS_HCPROC( void* src, void* dst, int srcSize, int dstCapacity, int compressionLevel );
    public delegate int PFNLZ4_SIZEOFSTATEHCPROC();
    public delegate int PFNLZ4_COMPRESS_HC_EXTSTATEHCPROC( void* state, void* src, void* dst, int srcSize, int maxDstSize, int compressionLevel );
#endif
    #endregion

    #region Methods
    static LZ4()
    {
		_handle = LibraryLoader.Load( typeof( LZ4 ) );
    }

    [ExternalMethod]
	public static PFNLZ4_VERSIONNUMBERPROC LZ4_versionNumber;
    [ExternalMethod]
	public static PFNLZ4_VERSIONSTRINGPROC LZ4_versionString;
    [ExternalMethod]
	public static PFNLZ4_COMPRESS_DEFAULTPROC LZ4_compress_default;
    [ExternalMethod]
	public static PFNLZ4_DECOMPRESS_SAFEPROC LZ4_decompress_safe;
    [ExternalMethod]
	public static PFNLZ4_COMPRESSBOUNDPROC LZ4_compressBound;
    [ExternalMethod]
	public static PFNLZ4_COMPRESS_FASTPROC LZ4_compress_fast;
    [ExternalMethod]
	public static PFNLZ4_SIZEOFSTATEPROC LZ4_sizeofState;
    [ExternalMethod]
	public static PFNLZ4_COMPRESS_FAST_EXTSTATEPROC LZ4_compress_fast_extState;
    [ExternalMethod]
	public static PFNLZ4_COMPRESS_DESTSIZEPROC LZ4_compress_destSize;
    [ExternalMethod]
	public static PFNLZ4_DECOMPRESS_FASTPROC LZ4_decompress_fast;
    [ExternalMethod]
	public static PFNLZ4_DECOMPRESS_SAFE_PARTIALPROC LZ4_decompress_safe_partial;
    [ExternalMethod]
	public static PFNLZ4_DECODERRINGBUFFERSIZEPROC LZ4_decoderRingBufferSize;
    [ExternalMethod]
	public static PFNLZ4_DECOMPRESS_SAFE_USINGDICTPROC LZ4_decompress_safe_usingDict;
    [ExternalMethod]
	public static PFNLZ4_DECOMPRESS_FAST_USINGDICTPROC LZ4_decompress_fast_usingDict;

#if LZ4HC_WRAPPER_IMPLEMENTATION
    [ExternalMethod]
	public static PFNLZ4_COMPRESS_HCPROC LZ4_compress_HC;
    [ExternalMethod]
	public static PFNLZ4_SIZEOFSTATEHCPROC LZ4_sizeofStateHC;
    [ExternalMethod]
	public static PFNLZ4_COMPRESS_HC_EXTSTATEHCPROC LZ4_compress_HC_extStateHC;
#endif
    #endregion
}
