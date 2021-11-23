using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingAbilities : MonoBehaviour
{
    public HeroChanger heroChanger;
    public List<Hero> heroes;
    public void UseAbilities()
    {
        var index = heroChanger.GetActiveHeroIndex;
        switch (index)
        {
            case 0: EelAbility(heroes[index]);
                break;
            case 1: HammerAbility(heroes[index]);
                break;
            case 2: HedgehogAbility(heroes[index]);
                break;
            case 3: SawAbility(heroes[index]); 
                break;
            case 4: TurtlesAbility(heroes[index]);
                break;
            
        }
        
    }
    private void SawAbility(Hero hero)
    {
        //Пилит дерево/врагов
        //Спавнит облако пыли(анимация)
        //В облаке удаляется препятствие
        Debug.Log("Способность пилы");
    }
    private void TurtlesAbility(Hero hero)
    {
        //Прячется в панцирь
        Debug.Log("Способность черепахи");
    }
    private void HedgehogAbility(Hero hero)
    {
        //Увеличивается или уменьшается с помощью анимации
        if(hero.transform.localScale == new Vector3(1,1,1))
            hero.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        else
            hero.transform.localScale = new Vector3(1,1,1);
        Debug.Log("Способность ежа");
    }
    private void EelAbility(Hero hero)
    {
        //Проходит через провода
        Debug.Log("Способность угря");
    }
    private void HammerAbility(Hero hero)
    {
        //Ломает головой камний/врагов
        //Спавнит облако пыли(анимация)
        //В облаке удаляется препятствие
        Debug.Log("Способность молота");
    }
}
