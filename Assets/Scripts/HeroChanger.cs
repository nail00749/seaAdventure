using UnityEngine;
using UnityEngine.UI;

public class HeroChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] heroes;
    private const int DefaultHeroIndex = 0;
    private int _currentHeroIndex;
    private GameObject _currentHero;
    public int GetActiveHeroIndex
    {
        get { return _currentHeroIndex; }
    }
    [SerializeField]
    private UsingAbilities usingAbilities;


    // Start is called before the first frame update
    void Start()
    {
        foreach (var hero in heroes)
        {
            hero.SetActive(false);
        }
        heroes[DefaultHeroIndex].SetActive(true);
        _currentHero = heroes[DefaultHeroIndex];
        _currentHeroIndex = DefaultHeroIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !usingAbilities.Using)
        {
            ChangeHero();
        }
    }

    private void ChangeHero()
    {
        _currentHeroIndex++;
        if (_currentHeroIndex >= heroes.Length)
            _currentHeroIndex = DefaultHeroIndex;

        foreach (var hero in heroes)
            hero.SetActive(false);

        heroes[_currentHeroIndex].SetActive(true);
        _currentHero = heroes[_currentHeroIndex];
    }

    public void ChangeActiveHeroIndex(int index)
    {   
        if(_currentHeroIndex == index)
            return;
        _currentHeroIndex = index;
        if(!usingAbilities.Using)
        {
            foreach (var hero in heroes)
                hero.SetActive(false);

            heroes[_currentHeroIndex].SetActive(true);
            _currentHero = heroes[_currentHeroIndex];
        }
            
    }

}