#region Using statements
using System;
using System.Runtime.InteropServices;

using LTP.Interop.InteropServices;
#endregion

[Library( "stbtt" )]
public static unsafe class STBTrueType // stb_truetype
{
	#region Fields / Properties
	private static IntPtr _handle;
	#endregion

	#region Constructors
	static STBTrueType()
	{
		_handle = LibraryLoader.Load( typeof( STBTrueType ) );
	}
	#endregion

	#region Constants
	public const int STBTT_MACSTYLE_DONTCARE = 0;
	public const int STBTT_MACSTYLE_BOLD = 1;
	public const int STBTT_MACSTYLE_ITALIC = 2;
	public const int STBTT_MACSTYLE_UNDERSCORE = 4;
	public const int STBTT_MACSTYLE_NONE = 8;
	public const int STBTT_VMOVE = 1;
	public const int STBTT_VLINE = 2;
	public const int STBTT_VCURVE = 3;
	public const int STBTT_VCUBIC = 4;
	public const int STBTT_PLATFORM_ID_UNICODE = 0;
	public const int STBTT_PLATFORM_ID_MAC = 1;
	public const int STBTT_PLATFORM_ID_ISO = 2;
	public const int STBTT_PLATFORM_ID_MICROSOFT = 3;
	public const int STBTT_UNICODE_EID_UNICODE_1_0 = 0;
	public const int STBTT_UNICODE_EID_UNICODE_1_1 = 1;
	public const int STBTT_UNICODE_EID_ISO_10646 = 2;
	public const int STBTT_UNICODE_EID_UNICODE_2_0_BMP = 3;
	public const int STBTT_UNICODE_EID_UNICODE_2_0_FULL = 4;
	public const int STBTT_MS_EID_SYMBOL = 0;
	public const int STBTT_MS_EID_UNICODE_BMP = 1;
	public const int STBTT_MS_EID_SHIFTJIS = 2;
	public const int STBTT_MS_EID_UNICODE_FULL = 10;
	public const int STBTT_MAC_EID_ROMAN = 0;
	public const int STBTT_MAC_EID_ARABIC = 4;
	public const int STBTT_MAC_EID_JAPANESE = 1;
	public const int STBTT_MAC_EID_HEBREW = 5;
	public const int STBTT_MAC_EID_CHINESE_TRAD = 2;
	public const int STBTT_MAC_EID_GREEK = 6;
	public const int STBTT_MAC_EID_KOREAN = 3;
	public const int STBTT_MAC_EID_RUSSIAN = 7;
	public const int STBTT_MS_LANG_ENGLISH = 1033;
	public const int STBTT_MS_LANG_ITALIAN = 1040;
	public const int STBTT_MS_LANG_CHINESE = 2052;
	public const int STBTT_MS_LANG_JAPANESE = 1041;
	public const int STBTT_MS_LANG_DUTCH = 1043;
	public const int STBTT_MS_LANG_KOREAN = 1042;
	public const int STBTT_MS_LANG_FRENCH = 1036;
	public const int STBTT_MS_LANG_RUSSIAN = 1049;
	public const int STBTT_MS_LANG_GERMAN = 1031;
	public const int STBTT_MS_LANG_SPANISH = 1033;
	public const int STBTT_MS_LANG_HEBREW = 1037;
	public const int STBTT_MS_LANG_SWEDISH = 1053;
	public const int STBTT_MAC_LANG_ENGLISH = 0;
	public const int STBTT_MAC_LANG_JAPANESE = 11;
	public const int STBTT_MAC_LANG_ARABIC = 12;
	public const int STBTT_MAC_LANG_KOREAN = 23;
	public const int STBTT_MAC_LANG_DUTCH = 4;
	public const int STBTT_MAC_LANG_RUSSIAN = 32;
	public const int STBTT_MAC_LANG_FRENCH = 1;
	public const int STBTT_MAC_LANG_SPANISH = 6;
	public const int STBTT_MAC_LANG_GERMAN = 2;
	public const int STBTT_MAC_LANG_SWEDISH = 5;
	public const int STBTT_MAC_LANG_HEBREW = 10;
	public const int STBTT_MAC_LANG_CHINESE_SIMPLIFIED = 33;
	public const int STBTT_MAC_LANG_ITALIAN = 3;
	public const int STBTT_MAC_LANG_CHINESE_TRAD = 19;
	#endregion

	#region Structs
	[StructLayout( LayoutKind.Sequential )]
	public struct stbrp_context
	{
		public int width;
		public int height;
		public int x;
		public int y;
		public int bottom_y;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbrp_node
	{
		public byte x;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbrp_rect
	{
		public int x;
		public int y;
		public int id;
		public int w;
		public int h;
		public int was_packed;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt__buf
	{
		public byte* data;
		public int cursor;
		public int size;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt_bakedchar
	{
		public ushort x0;
		public ushort y0;
		public ushort x1;
		public ushort y1;
		public float xoff;
		public float yoff;
		public float xadvance;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt_aligned_quad
	{
		public float x0;
		public float y0;
		public float s0;
		public float t0;
		public float x1;
		public float y1;
		public float s1;
		public float t1;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt_packedchar
	{
		public ushort x0;
		public ushort y0;
		public ushort x1;
		public ushort y1;
		public float xoff;
		public float yoff;
		public float xadvance;
		public float xoff2;
		public float yoff2;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt_pack_range
	{
		public float font_size;
		public int first_unicode_codepoint_in_range;
		public void* array_of_unicode_codepoints;
		public int num_chars;
		public void* chardata_for_range;
		public byte h_oversample;
		public byte v_oversample;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt_pack_context
	{
		public void* user_allocator_context;
		public void* pack_info;
		public int width;
		public int height;
		public int stride_in_bytes;
		public int padding;
		public uint h_oversample;
		public uint v_oversample;
		public byte* pixels;
		public void* nodes;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt_fontinfo
	{
		public void* userdata;
		public byte* data;
		public int fontstart;
		public int numGlyphs;
		public int loca;
		public int head;
		public int glyf;
		public int hhea;
		public int hmtx;
		public int kern;
		public int gpos;
		public int index_map;
		public int indexToLocFormat;
		public stbtt__buf cff;
		public stbtt__buf charstrings;
		public stbtt__buf gsubrs;
		public stbtt__buf subrs;
		public stbtt__buf fontdicts;
		public stbtt__buf fdselect;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt_vertex
	{
		public short x;
		public short y;
		public short cx;
		public short cy;
		public short cx1;
		public short cy1;
		public byte type;
		public byte padding;
	}

	[StructLayout( LayoutKind.Sequential )]
	public struct stbtt__bitmap
	{
		public int w;
		public int h;
		public int stride;
		public byte* pixels;
	}
	#endregion

	#region Delegates
	public delegate int PFNSTBTT_BAKEFONTBITMAPPROC( void* data, int offset, float pixel_height, void* pixels, int pw, int ph, int first_char, int num_chars, stbtt_bakedchar* chardata );
	public delegate void PFNSTBTT_GETBAKEDQUADPROC( stbtt_bakedchar* chardata, int pw, int ph, int char_index, float* xpos, float* ypos, stbtt_aligned_quad* q, int opengl_fillrule );
	public delegate int PFNSTBTT_PACKBEGINPROC( stbtt_pack_context* spc, void* pixels, int width, int height, int stride_in_bytes, int padding, void* alloc_context );
	public delegate void PFNSTBTT_PACKENDPROC( stbtt_pack_context* spc );
	public delegate int PFNSTBTT_PACKFONTRANGEPROC( stbtt_pack_context* spc, void* fontdata, int font_index, float font_size, int first_unicode_char_in_range, int num_chars_in_range, stbtt_packedchar* chardata_for_range );
	public delegate int PFNSTBTT_PACKFONTRANGESPROC( stbtt_pack_context* spc, void* fontdata, int font_index, stbtt_pack_range* ranges, int num_ranges );
	public delegate void PFNSTBTT_PACKSETOVERSAMPLINGPROC( stbtt_pack_context* spc, uint h_oversample, uint v_oversample );
	public delegate void PFNSTBTT_GETPACKEDQUADPROC( stbtt_packedchar* chardata, int pw, int ph, int char_index, float* xpos, float* ypos, stbtt_aligned_quad* q, int align_to_integer );
	public delegate int PFNSTBTT_PACKFONTRANGESGATHERRECTSPROC( stbtt_pack_context* spc, stbtt_fontinfo* info, stbtt_pack_range* ranges, int num_ranges, stbrp_rect* rects );
	public delegate void PFNSTBTT_PACKFONTRANGESPACKRECTSPROC( stbtt_pack_context* spc, stbrp_rect* rects, int num_rects );
	public delegate int PFNSTBTT_PACKFONTRANGESRENDERINTORECTSPROC( stbtt_pack_context* spc, stbtt_fontinfo* info, stbtt_pack_range* ranges, int num_ranges, stbrp_rect* rects );
	public delegate int PFNSTBTT_GETNUMBEROFFONTSPROC( void* data );
	public delegate int PFNSTBTT_GETFONTOFFSETFORINDEXPROC( void* data, int index );
	public delegate int PFNSTBTT_INITFONTPROC( stbtt_fontinfo* info, void* data, int offset );
	public delegate int PFNSTBTT_FINDGLYPHINDEXPROC( stbtt_fontinfo* info, int unicode_codepoint );
	public delegate float PFNSTBTT_SCALEFORPIXELHEIGHTPROC( stbtt_fontinfo* info, float pixels );
	public delegate float PFNSTBTT_SCALEFORMAPPINGEMTOPIXELSPROC( stbtt_fontinfo* info, float pixels );
	public delegate void PFNSTBTT_GETFONTVMETRICSPROC( stbtt_fontinfo* info, int* ascent, int* descent, int* lineGap );
	public delegate int PFNSTBTT_GETFONTVMETRICSOS2PROC( stbtt_fontinfo* info, int* typoAscent, int* typoDescent, int* typoLineGap );
	public delegate void PFNSTBTT_GETFONTBOUNDINGBOXPROC( stbtt_fontinfo* info, int* x0, int* y0, int* x1, int* y1 );
	public delegate void PFNSTBTT_GETCODEPOINTHMETRICSPROC( stbtt_fontinfo* info, int codepoint, int* advanceWidth, int* leftSideBearing );
	public delegate int PFNSTBTT_GETCODEPOINTKERNADVANCEPROC( stbtt_fontinfo* info, int ch1, int ch2 );
	public delegate int PFNSTBTT_GETCODEPOINTBOXPROC( stbtt_fontinfo* info, int codepoint, int* x0, int* y0, int* x1, int* y1 );
	public delegate void PFNSTBTT_GETGLYPHHMETRICSPROC( stbtt_fontinfo* info, int glyph_index, int* advanceWidth, int* leftSideBearing );
	public delegate int PFNSTBTT_GETGLYPHKERNADVANCEPROC( stbtt_fontinfo* info, int glyph1, int glyph2 );
	public delegate int PFNSTBTT_GETGLYPHBOXPROC( stbtt_fontinfo* info, int glyph_index, int* x0, int* y0, int* x1, int* y1 );
	public delegate int PFNSTBTT_ISGLYPHEMPTYPROC( stbtt_fontinfo* info, int glyph_index );
	public delegate int PFNSTBTT_GETCODEPOINTSHAPEPROC( stbtt_fontinfo* info, int unicode_codepoint, void** vertices );
	public delegate int PFNSTBTT_GETGLYPHSHAPEPROC( stbtt_fontinfo* info, int glyph_index, void** vertices );
	public delegate void PFNSTBTT_FREESHAPEPROC( stbtt_fontinfo* info, stbtt_vertex* vertices );
	public delegate void PFNSTBTT_FREEBITMAPPROC( void* bitmap, void* userdata );
	public delegate void* PFNSTBTT_GETCODEPOINTBITMAPPROC( stbtt_fontinfo* info, float scale_x, float scale_y, int codepoint, int* width, int* height, int* xoff, int* yoff );
	public delegate void* PFNSTBTT_GETCODEPOINTBITMAPSUBPIXELPROC( stbtt_fontinfo* info, float scale_x, float scale_y, float shift_x, float shift_y, int codepoint, int* width, int* height, int* xoff, int* yoff );
	public delegate void PFNSTBTT_MAKECODEPOINTBITMAPPROC( stbtt_fontinfo* info, void* output, int out_w, int out_h, int out_stride, float scale_x, float scale_y, int codepoint );
	public delegate void PFNSTBTT_MAKECODEPOINTBITMAPSUBPIXELPROC( stbtt_fontinfo* info, void* output, int out_w, int out_h, int out_stride, float scale_x, float scale_y, float shift_x, float shift_y, int codepoint );
	public delegate void PFNSTBTT_MAKECODEPOINTBITMAPSUBPIXELPREFILTERPROC( stbtt_fontinfo* info, void* output, int out_w, int out_h, int out_stride, float scale_x, float scale_y, float shift_x, float shift_y, int oversample_x, int oversample_y, float* sub_x, float* sub_y, int codepoint );
	public delegate void PFNSTBTT_GETCODEPOINTBITMAPBOXPROC( stbtt_fontinfo* font, int codepoint, float scale_x, float scale_y, int* ix0, int* iy0, int* ix1, int* iy1 );
	public delegate void PFNSTBTT_GETCODEPOINTBITMAPBOXSUBPIXELPROC( stbtt_fontinfo* font, int codepoint, float scale_x, float scale_y, float shift_x, float shift_y, int* ix0, int* iy0, int* ix1, int* iy1 );
	public delegate void* PFNSTBTT_GETGLYPHBITMAPPROC( stbtt_fontinfo* info, float scale_x, float scale_y, int glyph, int* width, int* height, int* xoff, int* yoff );
	public delegate void* PFNSTBTT_GETGLYPHBITMAPSUBPIXELPROC( stbtt_fontinfo* info, float scale_x, float scale_y, float shift_x, float shift_y, int glyph, int* width, int* height, int* xoff, int* yoff );
	public delegate void PFNSTBTT_MAKEGLYPHBITMAPPROC( stbtt_fontinfo* info, void* output, int out_w, int out_h, int out_stride, float scale_x, float scale_y, int glyph );
	public delegate void PFNSTBTT_MAKEGLYPHBITMAPSUBPIXELPROC( stbtt_fontinfo* info, void* output, int out_w, int out_h, int out_stride, float scale_x, float scale_y, float shift_x, float shift_y, int glyph );
	public delegate void PFNSTBTT_MAKEGLYPHBITMAPSUBPIXELPREFILTERPROC( stbtt_fontinfo* info, void* output, int out_w, int out_h, int out_stride, float scale_x, float scale_y, float shift_x, float shift_y, int oversample_x, int oversample_y, float* sub_x, float* sub_y, int glyph );
	public delegate void PFNSTBTT_GETGLYPHBITMAPBOXPROC( stbtt_fontinfo* font, int glyph, float scale_x, float scale_y, int* ix0, int* iy0, int* ix1, int* iy1 );
	public delegate void PFNSTBTT_GETGLYPHBITMAPBOXSUBPIXELPROC( stbtt_fontinfo* font, int glyph, float scale_x, float scale_y, float shift_x, float shift_y, int* ix0, int* iy0, int* ix1, int* iy1 );
	public delegate void PFNSTBTT_RASTERIZEPROC( stbtt__bitmap* result, float flatness_in_pixels, stbtt_vertex* vertices, int num_verts, float scale_x, float scale_y, float shift_x, float shift_y, int x_off, int y_off, int invert, void* userdata );
	public delegate void PFNSTBTT_FREESDFPROC( void* bitmap, void* userdata );
	public delegate void* PFNSTBTT_GETGLYPHSDFPROC( stbtt_fontinfo* info, float scale, int glyph, int padding, byte onedge_value, float pixel_dist_scale, int* width, int* height, int* xoff, int* yoff );
	public delegate void* PFNSTBTT_GETCODEPOINTSDFPROC( stbtt_fontinfo* info, float scale, int codepoint, int padding, byte onedge_value, float pixel_dist_scale, int* width, int* height, int* xoff, int* yoff );
	public delegate int PFNSTBTT_FINDMATCHINGFONTPROC( void* fontdata, void* name, int flags );
	public delegate int PFNSTBTT_COMPAREUTF8TOUTF16_BIGENDIANPROC( void* s1, int len1, void* s2, int len2 );
	public delegate void* PFNSTBTT_GETFONTNAMESTRINGPROC( stbtt_fontinfo* font, int* length, int platformID, int encodingID, int languageID, int nameID );
	#endregion

	#region Methods
	public static PFNSTBTT_BAKEFONTBITMAPPROC stbtt_BakeFontBitmap;
	public static PFNSTBTT_GETBAKEDQUADPROC stbtt_GetBakedQuad;
	public static PFNSTBTT_PACKBEGINPROC stbtt_PackBegin;
	public static PFNSTBTT_PACKENDPROC stbtt_PackEnd;
	public static PFNSTBTT_PACKFONTRANGEPROC stbtt_PackFontRange;
	public static PFNSTBTT_PACKFONTRANGESPROC stbtt_PackFontRanges;
	public static PFNSTBTT_PACKSETOVERSAMPLINGPROC stbtt_PackSetOversampling;
	public static PFNSTBTT_GETPACKEDQUADPROC stbtt_GetPackedQuad;
	public static PFNSTBTT_PACKFONTRANGESGATHERRECTSPROC stbtt_PackFontRangesGatherRects;
	public static PFNSTBTT_PACKFONTRANGESPACKRECTSPROC stbtt_PackFontRangesPackRects;
	public static PFNSTBTT_PACKFONTRANGESRENDERINTORECTSPROC stbtt_PackFontRangesRenderIntoRects;
	public static PFNSTBTT_GETNUMBEROFFONTSPROC stbtt_GetNumberOfFonts;
	public static PFNSTBTT_GETFONTOFFSETFORINDEXPROC stbtt_GetFontOffsetForIndex;
	public static PFNSTBTT_INITFONTPROC stbtt_InitFont;
	public static PFNSTBTT_FINDGLYPHINDEXPROC stbtt_FindGlyphIndex;
	public static PFNSTBTT_SCALEFORPIXELHEIGHTPROC stbtt_ScaleForPixelHeight;
	public static PFNSTBTT_SCALEFORMAPPINGEMTOPIXELSPROC stbtt_ScaleForMappingEmToPixels;
	public static PFNSTBTT_GETFONTVMETRICSPROC stbtt_GetFontVMetrics;
	public static PFNSTBTT_GETFONTVMETRICSOS2PROC stbtt_GetFontVMetricsOS2;
	public static PFNSTBTT_GETFONTBOUNDINGBOXPROC stbtt_GetFontBoundingBox;
	public static PFNSTBTT_GETCODEPOINTHMETRICSPROC stbtt_GetCodepointHMetrics;
	public static PFNSTBTT_GETCODEPOINTKERNADVANCEPROC stbtt_GetCodepointKernAdvance;
	public static PFNSTBTT_GETCODEPOINTBOXPROC stbtt_GetCodepointBox;
	public static PFNSTBTT_GETGLYPHHMETRICSPROC stbtt_GetGlyphHMetrics;
	public static PFNSTBTT_GETGLYPHKERNADVANCEPROC stbtt_GetGlyphKernAdvance;
	public static PFNSTBTT_GETGLYPHBOXPROC stbtt_GetGlyphBox;
	public static PFNSTBTT_ISGLYPHEMPTYPROC stbtt_IsGlyphEmpty;
	public static PFNSTBTT_GETCODEPOINTSHAPEPROC stbtt_GetCodepointShape;
	public static PFNSTBTT_GETGLYPHSHAPEPROC stbtt_GetGlyphShape;
	public static PFNSTBTT_FREESHAPEPROC stbtt_FreeShape;
	public static PFNSTBTT_FREEBITMAPPROC stbtt_FreeBitmap;
	public static PFNSTBTT_GETCODEPOINTBITMAPPROC stbtt_GetCodepointBitmap;
	public static PFNSTBTT_GETCODEPOINTBITMAPSUBPIXELPROC stbtt_GetCodepointBitmapSubpixel;
	public static PFNSTBTT_MAKECODEPOINTBITMAPPROC stbtt_MakeCodepointBitmap;
	public static PFNSTBTT_MAKECODEPOINTBITMAPSUBPIXELPROC stbtt_MakeCodepointBitmapSubpixel;
	public static PFNSTBTT_MAKECODEPOINTBITMAPSUBPIXELPREFILTERPROC stbtt_MakeCodepointBitmapSubpixelPrefilter;
	public static PFNSTBTT_GETCODEPOINTBITMAPBOXPROC stbtt_GetCodepointBitmapBox;
	public static PFNSTBTT_GETCODEPOINTBITMAPBOXSUBPIXELPROC stbtt_GetCodepointBitmapBoxSubpixel;
	public static PFNSTBTT_GETGLYPHBITMAPPROC stbtt_GetGlyphBitmap;
	public static PFNSTBTT_GETGLYPHBITMAPSUBPIXELPROC stbtt_GetGlyphBitmapSubpixel;
	public static PFNSTBTT_MAKEGLYPHBITMAPPROC stbtt_MakeGlyphBitmap;
	public static PFNSTBTT_MAKEGLYPHBITMAPSUBPIXELPROC stbtt_MakeGlyphBitmapSubpixel;
	public static PFNSTBTT_MAKEGLYPHBITMAPSUBPIXELPREFILTERPROC stbtt_MakeGlyphBitmapSubpixelPrefilter;
	public static PFNSTBTT_GETGLYPHBITMAPBOXPROC stbtt_GetGlyphBitmapBox;
	public static PFNSTBTT_GETGLYPHBITMAPBOXSUBPIXELPROC stbtt_GetGlyphBitmapBoxSubpixel;
	public static PFNSTBTT_RASTERIZEPROC stbtt_Rasterize;
	public static PFNSTBTT_FREESDFPROC stbtt_FreeSDF;
	public static PFNSTBTT_GETGLYPHSDFPROC stbtt_GetGlyphSDF;
	public static PFNSTBTT_GETCODEPOINTSDFPROC stbtt_GetCodepointSDF;
	public static PFNSTBTT_FINDMATCHINGFONTPROC stbtt_FindMatchingFont;
	public static PFNSTBTT_COMPAREUTF8TOUTF16_BIGENDIANPROC stbtt_CompareUTF8toUTF16_bigendian;
	public static PFNSTBTT_GETFONTNAMESTRINGPROC stbtt_GetFontNameString;
	#endregion
}