using UnityEngine;

public class HeroChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] heroes;
    private const int DefaultHeroIndex = 0;
    private int _currentHeroIndex;
    private GameObject _currentHero;
    
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _currentHero = ChangeHero();
        }
    }

    private GameObject ChangeHero()
    {
        _currentHeroIndex++;
        if (_currentHeroIndex >= heroes.Length)
            _currentHeroIndex = DefaultHeroIndex;

        foreach (var hero in heroes)
            hero.SetActive(false);

        heroes[_currentHeroIndex].SetActive(true);
        return heroes[_currentHeroIndex];
    }
}