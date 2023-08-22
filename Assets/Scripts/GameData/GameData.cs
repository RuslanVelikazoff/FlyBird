namespace Data
{
    [System.Serializable]
    public class GameData
    {
        public int highScore;

        public bool EasyLevel;
        public bool MidleLevel;
        public bool HardLevel;

        public GameData()
        {
            highScore = 0;

            EasyLevel = true;
            MidleLevel = false;
            HardLevel = false;
        }
    }
}
