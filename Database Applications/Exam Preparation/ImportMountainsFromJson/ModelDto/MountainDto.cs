namespace ImportMountainsFromJson.ModelDto
{
    class MountainDto
    {
        private PeakDto[] peaks;

        public MountainDto()
        {
            this.peaks = new PeakDto[0];
        }

        public string MountainName { get; set; }

        public PeakDto[] Peaks
        {
            get
            {
                return this.peaks;

            }

            set
            {
                this.peaks = value;

            }
        }

        public string[] Countries { get; set; }
    }
}
