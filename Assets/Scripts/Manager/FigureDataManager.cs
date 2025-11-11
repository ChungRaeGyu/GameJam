using UnityEngine;

public class FigureDataManager : Singleton<FigureDataManager>
{
    ///<summary>
    ///수치 데이터를 관리하는 싱글톤 클래스
    /// </summary>

    //event 관련 수치   
    public const float eventTime = 2f;

    //spawn 관련 수치

    public const int normalSpawnRate = 80;
    public const int rareSpawnRate = 20;

    public static readonly int[] upgraderareSpawnRate = new int[2] { 5, 9 };
    public const int plusRareRate = 10;
}
