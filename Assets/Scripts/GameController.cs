using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
	[SerializeField]
	private LevelManager _levelManager;
	[SerializeField]
	private GameResultsView _gameResultPrefab;
	[SerializeField]
	private Transform _container;
	[SerializeField]
	private int _levelTime;
	[SerializeField]
	private Timer _timer;

	[SerializeField]
	private Text _maxScoreText;
	[SerializeField]
	private Text _currentScoreText;
	[SerializeField]
	private GameObject _gamePanel;
	[SerializeField]
	private GameObject _progressBar;
	[SerializeField]
	private AudioSource _clickSound;

	[Header("Clickables")]
	[SerializeField]
	private Clickable _clickable;
	[SerializeField]
	private Clickable _doubleBonusItem;
	[SerializeField]
	private Clickable _bigBonusItem;
	[SerializeField]
	private Clickable _freezeBonusItem;

	[Header("Bonus timers")]
	[SerializeField]
    private Timer _doubleBonusTimer;
	[SerializeField]
	private Timer _bigBonusTimer;
	[SerializeField]
	private Timer _freezeBonusTimer;

	private int _scores = 0;
	private SpriteRenderer _gameZone;
	[SerializeField]
	private int _maxScore = 20;

	private bool _doubleBonus, _bigSizeBonus, _freezeBonus;

	[SerializeField]
	private SpriteRenderer _cookie;
	[SerializeField]
	private SpriteRenderer _background;

	[SerializeField]
	private LevelInfoLoader _levelInfoLoader;

    private void Awake()
	{
		InititializeBonusesTimers();

		_gameZone = _gamePanel.GetComponent<SpriteRenderer>();
		_progressBar.GetComponent<Image>().fillAmount = 0;
		_maxScoreText.text = "Max " + _maxScore.ToString();
		_currentScoreText.text = _scores.ToString() + "/" + _maxScore.ToString();

		_clickable.SetPosition(GetRandomPosition());

		_cookie.sprite = _levelManager.Cookie;
		_background.sprite = _levelManager.LevelBackground;
	}


    IEnumerator Start()
	{
		_timer.OnTimeOut += OnTimeOutHandler;
		_clickable.OnClick += OnClickHandler;

		_doubleBonusItem.OnClick += ActivateDoubleBonus;
		_freezeBonusItem.OnClick += ActivateFreezeBonus;
		_bigBonusItem.OnClick += ActivateBigSizeBonus;

		yield return new WaitForSeconds(1f);

		// Start game...
		_timer.StartTimer(_levelTime);
	}


    private void OnTimeOutHandler()
	{
		_levelInfoLoader.AddPlayerResult("MY NAME", _timer.CurrentTime, _levelManager.LevelName);

		GameResultsView gameResultsView = Instantiate(_gameResultPrefab, _container);
		gameResultsView.Initialize(_levelManager.CurentLevel);

		_timer.Pause(true);
	}

	private void OnClickHandler()
    {

		if (_doubleBonus)
        {
			_scores += 2;
			_progressBar.GetComponent<Image>().fillAmount += 1f / _maxScore;
		}
		else
			_scores += 1;


		if(_scores >= _maxScore)
        {
			_scores = _maxScore;
			_levelInfoLoader.AddPlayerResult("MY NAME", _timer.CurrentTime, _levelManager.LevelName);
			GameResultsView gameResultsView = Instantiate(_gameResultPrefab, _container);
			gameResultsView.Initialize(_levelManager.CurentLevel);
			_timer.Pause(true);
		}

		_currentScoreText.text = _scores.ToString() + "/" + _maxScore.ToString();

		CheckBonuses();

		if (_bigSizeBonus)
			_clickable.GetComponent<Transform>().transform.localScale = new Vector3(2, 2, 1);
		else
			_clickable.GetComponent<Transform>().transform.localScale = new Vector3(1, 1, 1);

		_progressBar.GetComponent<Image>().fillAmount += 1f / _maxScore;
		_clickSound.Play();

		_clickable.SetPosition(GetRandomPosition());

		float randomBonus = UnityEngine.Random.value;
		if(randomBonus < 0.2f)
        {
			System.Random random = new System.Random();
			int bonus = random.Next(0, 3);
			if (bonus == 0)
			{
				_bigBonusItem.SetActive(true);
				_bigBonusItem.SetPosition(GetRandomPosition());
			}
			else if (bonus == 1)
			{
				_freezeBonusItem.SetActive(true);
				_freezeBonusItem.SetPosition(GetRandomPosition());
			}
			else if (bonus == 2)
			{
				_doubleBonusItem.SetActive(true);
				_doubleBonusItem.SetPosition(GetRandomPosition());
			}
        }
	}

    private void CheckBonuses()
    {
        if (_doubleBonus && _doubleBonusTimer.IsTimeOut)
        {
			_doubleBonus = false;
			_doubleBonusItem.SetActive(false);
		}
		if (_freezeBonus && _freezeBonusTimer.IsTimeOut)
		{
			_freezeBonus = false;
			_freezeBonusItem.SetActive(false);
		}
		if (_bigSizeBonus && _bigBonusTimer.IsTimeOut)
		{
			_bigSizeBonus = false;
			_bigBonusItem.SetActive(false);
		}
	}

	private void InititializeBonusesTimers()
    {
		_doubleBonusTimer.OnTimeOut += () => _doubleBonusTimer.SetActive(false);
		_freezeBonusTimer.OnTimeOut += () =>
		{
			_freezeBonusTimer.SetActive(false);
			_timer.Pause(false);
		};

		_bigBonusTimer.OnTimeOut += () => _bigBonusTimer.SetActive(false);

		_doubleBonusTimer.SetActive(false);
		_freezeBonusTimer.SetActive(false);
		_bigBonusTimer.SetActive(false);
	}

    private void ActivateDoubleBonus()
    {
        _doubleBonus = true;
		_doubleBonusTimer.SetActive(true);
		_doubleBonusTimer.StartTimer(5);
		_doubleBonusItem.SetActive(false);
		Debug.Log("activate" + _doubleBonus);
	}

	private void ActivateFreezeBonus()
	{
		_freezeBonus = true;
		_freezeBonusTimer.SetActive(true);
		_freezeBonusTimer.StartTimer(5);
		_freezeBonusItem.SetActive(false);
		_timer.Pause(true);
	}

	private void ActivateBigSizeBonus()
	{
		_bigSizeBonus = true;
		_bigBonusTimer.SetActive(true);
		_bigBonusTimer.StartTimer(5);
		_bigBonusItem.SetActive(false);
	}

	private Vector2 GetRandomPosition()
    {
		float posX, posY;
		posX = Random.Range(_gameZone.bounds.min.x, _gameZone.bounds.max.x);
        posY = Random.Range(_gameZone.bounds.min.y, _gameZone.bounds.max.y);
		return new Vector2(posX, posY);
    }

	private void OnDestroy()
	{
		_timer.OnTimeOut -= OnTimeOutHandler;
		_clickable.OnClick -= OnClickHandler;
	}
}
