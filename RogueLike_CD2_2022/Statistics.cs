namespace RogueLike_CD2_2022; 

public class Statistics {
    public int Level;
    public int CurrentHP;
    public int MaxHP;
    public int CurrentXP;
    public int TargetXP;
    public int Attack;
    public int Defense;

    public Statistics(int level, int currentHp, int maxHp, int currentXp, int targetXp, int attack, int defense) {
        Level = level;
        CurrentHP = currentHp;
        MaxHP = maxHp;
        CurrentXP = currentXp;
        TargetXP = targetXp;
        Attack = attack;
        Defense = defense;
    }

    public void AddExperience(int experience) {
        CurrentXP += experience;
        CheckLevelUp();
    }

    private void setTargetExperience() {
        TargetXP = (int)Math.Round(4 * Math.Pow(Level, 3) / 5);
    }

    public void CheckLevelUp() {
        while (CurrentXP >= TargetXP) {
            CurrentXP -= TargetXP;
            Level++;
            StatisticsGrowth();
            setTargetExperience();
            
        }
    }

    /*----------------------------------------------------------------------
     DICE SYSTEM & VALUES FOR LIFE & STATISTICS
    ------------------------------------------------------------------------
    Fast_Stat = 4D2 --- Medium_Stat = 2D2 --- Slow_Stat = 1D2
    Fast_Health = 9D6 --- Medium_Health = 5D6 --- Slow_Health = 3D4

    Fast_Stat     :     Max 8 Min 4         Fast_Health     :     Max 54 Min 9
    Medium_Stat   :     Max 4 Min 2         Medium_Health   :     Max 30 Min 5
    Slow_Stat     :     Max 2 Min 1         Slow_Health     :     Max 12 Min 3
    ----------------------------------------------------------------------*/
    
    private int rollDice(int number, int faces) {
        var value = 0;
        for (var i = 0; i < number; i++) {
            value += new Random().Next(1, faces + 1);
        }
        return value;
    }

    public void StatisticsGrowth() {
        MaxHP += rollDice(5, 6);
        Attack += rollDice(2, 2);
        Defense += rollDice(2, 2);
    }

    public void ResetHP() {
        CurrentHP = MaxHP;
    }

    public void IncreaseHP(int value) {
        CurrentHP = Math.Min(CurrentHP + value, MaxHP);
    }
    
    public void DecreaseHP(int value) {
        CurrentHP = Math.Max(CurrentHP - value, 0);
    }

    public int Damage(int targetDefense) {
        return Math.Max(Attack - targetDefense, 1);
    }
}