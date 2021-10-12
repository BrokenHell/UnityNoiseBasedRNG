namespace Zodiark.Utilities
{
    /// <summary>
    /// Noise-based RNG based on Squirrel's idea : http://eiserloh.net/noise/SquirrelNoise5.hpp
    /// </summary>
    public static class NoiseBasedRNG
    {
        const float ONE_OVER_MAX_UINT = (1.0f / uint.MaxValue);
        const float ONE_OVER_MAX_INT = (1.0f / int.MaxValue);
        const int PRIME_NUMBER = 198491317; // Large prime number with non-boring bits
        const int PRIME_NUMBER_2 = 6542989; // Large prime number with distinct and non-boring bits
        const int PRIME_NUMBER_3 = 357239; // Large prime number with distinct and non-boring bits

        const uint SQ5_BIT_NOISE1 = 0xd2a80a3f; // 11010010101010000000101000111111
        const uint SQ5_BIT_NOISE2 = 0xa884f197; // 10101000100001001111000110010111
        const uint SQ5_BIT_NOISE3 = 0x6C736F4B; // 01101100011100110110111101001011
        const uint SQ5_BIT_NOISE4 = 0xB79F3ABB; // 10110111100111110011101010111011
        const uint SQ5_BIT_NOISE5 = 0x1b56c4f5; // 00011011010101101100010011110101

        #region Public Methods

        /// <summary>
        /// Get noise-based RNG unit value with 1D position
        /// </summary>
        /// <param name="position">index position of 1D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static uint Get1dNoiseUnit(int position, uint seed = 0)
        {
            return SquirrelNoise5(position, seed);
        }

        /// <summary>
        /// Get noise-based RNG unit value with 2D position
        /// </summary>
        /// <param name="positionX">index position X of 2D noise map</param>
        /// <param name="positionY">index position Y of 2D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static uint Get2dNoiseUnit(int positionX, int positionY, uint seed = 0)
        {
            return Get1dNoiseUnit(positionX + (PRIME_NUMBER * positionY), seed);
        }

        /// <summary>
        /// Get noise-based RNG unit value with 3D dimension
        /// </summary>
        /// <param name="positionX">index position X of 3D noise map</param>
        /// <param name="positionY">index position Y of 3D noise map</param>
        /// <param name="positionZ">index position Z of 3D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static uint Get3dNoiseUnit(int positionX, int positionY, int positionZ, uint seed = 0)
        {
            return Get1dNoiseUnit(positionX + (PRIME_NUMBER * positionY) + (PRIME_NUMBER_2 * positionZ), seed);
        }

        /// <summary>
        /// Get noise-based RNG unit value with 4D position
        /// </summary>
        /// <param name="positionX">index position X of 4D noise map</param>
        /// <param name="positionY">index position Y of 4D noise map</param>
        /// <param name="positionZ">index position Z of 4D noise map</param>
        /// <param name="positionT">index position T of 4D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static uint Get4dNoiseUnit(int positionX, int positionY, int positionZ, int positionT, uint seed = 0)
        {
            return Get1dNoiseUnit(positionX + (PRIME_NUMBER * positionY) + (PRIME_NUMBER_2 * positionZ) + (PRIME_NUMBER_3 * positionT), seed);
        }

        /// <summary>
        /// Get noise-based value within [0.0..1.0] (range is inclusive) with 1D position
        /// </summary>
        /// <param name="position">index position of 1D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get1dNoiseZeroToOne(int position, uint seed = 0)
        {
            return SquirrelNoise5(position, seed) * ONE_OVER_MAX_UINT; // / (float)uint.MaxValue;
        }

        /// <summary>
        /// Get noise-based value within [0.0..1.0] (range is inclusive) with 2D position
        /// </summary>
        /// <param name="positionX">index position X of 2D noise map</param>
        /// <param name="positionY">index position Y of 2D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get2dNoiseZeroToOne(int positionX, int positionY, uint seed = 0)
        {
            return Get2dNoiseUnit(positionX, positionY, seed) * ONE_OVER_MAX_UINT;
        }

        /// <summary>
        /// Get noise-based value within [0.0..1.0] (range is inclusive) with 3D position
        /// </summary>
        /// <param name="positionX">index position X of 3D noise map</param>
        /// <param name="positionY">index position Y of 3D noise map</param>
        /// <param name="positionZ">index position Z of 3D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get3dNoiseZeroToOne(int positionX, int positionY, int positionZ, uint seed = 0)
        {
            return Get3dNoiseUnit(positionX, positionY, positionZ, seed) * ONE_OVER_MAX_UINT;
        }

        /// <summary>
        /// Get noise-based value within [0.0..1.0] (range is inclusive) with 4D position
        /// </summary>
        /// <param name="positionX">index position X of 4D noise map</param>
        /// <param name="positionY">index position Y of 4D noise map</param>
        /// <param name="positionZ">index position Z of 4D noise map</param>
        /// <param name="positionT">index position T of 4D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get4dNoiseZeroToOne(int positionX, int positionY, int positionZ, int positionT, uint seed = 0)
        {
            return Get4dNoiseUnit(positionX, positionY, positionZ, positionT, seed) * ONE_OVER_MAX_UINT;
        }

        /// <summary>
        /// Get noise-based value within [-1.0..1.0] (range is inclusive) with 1D position
        /// </summary>
        /// <param name="position">index position of 1D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get1dNoiseNegOneToOne(int position, uint seed = 0)
        {
            return (int)SquirrelNoise5(position, seed) * ONE_OVER_MAX_INT;
        }

        /// <summary>
        /// Get noise-based value within [-1.0..1.0] (range is inclusive) with 2D position
        /// </summary>
        /// <param name="positionX">index position X of 2D noise map</param>
        /// <param name="positionY">index position X of 2D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get2dNoiseNegOneToOne(int positionX, int positionY, uint seed = 0)
        {
            return (int)Get2dNoiseUnit(positionX, positionY, seed) * ONE_OVER_MAX_INT;
        }

        /// <summary>
        /// Get noise-based value within [-1.0..1.0] (range is inclusive) with 3D position
        /// </summary>
        /// <param name="positionX">index position X of 3D noise map</param>
        /// <param name="positionY">index position Y of 3D noise map</param>
        /// <param name="positionZ">index position Z of 3D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get3dNoiseNegOneToOne(int positionX, int positionY, int positionZ, uint seed = 0)
        {
            return (int)Get3dNoiseUnit(positionX, positionY, positionZ, seed) * ONE_OVER_MAX_INT;
        }

        /// <summary>
        /// Get noise-based value within [-1.0..1.0] (range is inclusive) with 4D position
        /// </summary>
        /// <param name="positionX">index position X of 4D noise map</param>
        /// <param name="positionY">index position Y of 4D noise map</param>
        /// <param name="positionZ">index position Z of 4D noise map</param>
        /// <param name="positionT">index position T of 4D noise map</param>
        /// <param name="seed">random seed</param>
        /// <returns></returns>
        public static float Get4dNoiseNegOneToOne(int positionX, int positionY, int positionZ, int positionT, uint seed = 0)
        {
            return (int)Get4dNoiseUnit(positionX, positionY, positionZ, positionT, seed) * ONE_OVER_MAX_INT;
        }
        #endregion

        #region Private Methods

        //-----------------------------------------------------------------------------------------------
        // Fast hash of an int32 into a different (unrecognizable) uint32.
        //
        // Returns an unsigned integer containing 32 reasonably-well-scrambled bits, based on the hash
        //	of a given (signed) integer input parameter (position/index) and [optional] seed.  Kind of
        //	like looking up a value in an infinitely large table of previously generated random numbers.
        //-------------------------------------------------------------------------------------------------
        public static uint SquirrelNoise5(int position, uint seed = 0)
        {
            uint mangledBits = (uint)position;
            mangledBits *= SQ5_BIT_NOISE1;
            mangledBits += seed;
            mangledBits ^= (mangledBits >> 9);
            mangledBits += SQ5_BIT_NOISE2;
            mangledBits ^= (mangledBits >> 11);
            mangledBits *= SQ5_BIT_NOISE3;
            mangledBits ^= (mangledBits >> 13);
            mangledBits += SQ5_BIT_NOISE4;
            mangledBits ^= (mangledBits >> 15);
            mangledBits *= SQ5_BIT_NOISE5;
            mangledBits ^= (mangledBits >> 17);
            return mangledBits;
        }

        #endregion
    }
}