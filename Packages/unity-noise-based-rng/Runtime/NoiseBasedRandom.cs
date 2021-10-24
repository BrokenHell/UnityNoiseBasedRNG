namespace Zodiark.Utilities
{
    /// <summary>
    /// Noise-based random wrapper to help build procedure content like mountain, village...
    /// </summary>
    public class NoiseBasedRandom
    {
        #region Fields
        /// <summary>
        /// Current position
        /// </summary>
        private int position;

        /// <summary>
        /// Current seed
        /// </summary>
        public uint seed = (uint)(System.DateTime.Now.Ticks & 0x0000FFFF);
        #endregion

        #region Properties
        /// <summary>
        /// Get or set current position of the noise-map index
        /// </summary>
        public int CurrentPosition
        {
            get => position;
            set => position = value;
        }

        /// <summary>
        /// Returns random value within range [0.0..1.0] ( range is exclusive )
        /// </summary>
        public float Value => NoiseBasedRNG.Get1dNoiseZeroToOne(position++, seed);
        /// <summary>
        /// Get current seed
        /// </summary>
        public uint Seed => seed;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor with seed and starting position
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="startPosition"></param>
        public NoiseBasedRandom(uint seed, int startPosition = 0)
        {
            this.seed = seed;
            this.position = startPosition;
        }

        /// <summary>
        /// Constructor with seed by string and starting position
        /// </summary>
        /// <param name="seedString"></param>
        /// <param name="startPosition"></param>
        public NoiseBasedRandom(string seedString, int startPosition = 0)
        {
            this.seed = (uint)seedString.GetHashCode();
            this.position = startPosition;
        }

        /// <summary>
        /// Default Contructor
        /// </summary>
        public NoiseBasedRandom()
        {
            this.position = 0;
        }
        #endregion

        #region Public Methods

        ///// <summary>
        ///// Return random bool value
        ///// </summary>
        ///// <returns></returns>
        //public bool NextBool() => (NoiseBasedRNG.Get1dNoiseUnit(position++, seed) & 1) == 1;

        ///// <summary>
        ///// Return random int value
        ///// </summary>
        ///// <returns></returns>
        //public int NextInt() => (int)NoiseBasedRNG.Get1dNoiseUnit(position++, seed) ^ int.MinValue;

        /// <summary>
        /// Returns int value within [min..max(exclusive)] 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int Range(int min, int max)
            => min + (int)(NoiseBasedRNG.Get1dNoiseUnit(position++, seed) % (max - min));

        /// <summary>
        /// Returns float value within [min..max(exclusive)]
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public float Range(float min, float max)
            => min + (NoiseBasedRNG.Get1dNoiseZeroToOne(position++, seed) * (max - min));
        #endregion
    }
}

