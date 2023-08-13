public interface TalentPoint 
{
    public int LevelUp();

    public string GetTitle();
    public int GetMaxLevel();
    public int GetCurrentLevel();

    public string GetDescription();

    public int GetMaximumTalentPoints();
    public int GetCurrentTalentPoints();

    public int[] GetConnectedTalentPoints();
}