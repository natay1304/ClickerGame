using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
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
	[SerializeField]
	private GameObject _gameOver;

	[SerializeField]
	private GameObject _item;
	[SerializeField]
	private GameObject _doubleBonusItem;
	[SerializeField]
	private GameObject _bigBonusItem;
	[SerializeField]
	private GameObject _freezeBonusItem;

	[SerializeField]
	private Clickable _clickable;

	private int _scores = 0;
	private Transform _itemTransform;
	private SpriteRenderer _gameZone;
	private int _maxScore = 20;

	private bool _isDouble, _isBigItem, _isFreeze;

	// TODO: Item bonuses


	private void Awake()
	{
		_gameZone = _gamePanel.GetComponent<SpriteRenderer>();
		_progressBar.GetComponent<Image>().fillAmount = 0;
		_maxScoreText.text = "Max score " + _maxScore.ToString();
		_currentScoreText.text = _scores.ToString() + "/" + _maxScore.ToString();
		ChangeItemPosition();
	}

	IEnumerator Start()
	{
		_timer.OnTimeOut += OnTimeOutHandler;
		_clickable.OnClick += OnClickHandler;
		yield return new WaitForSeconds(3f);

		// Start game...
		_timer.Start(_levelTime);
	}

	private void OnTimeOutHandler()
	{
		if (_scores >= _maxScore)
			_gameOver.GetComponentInChildren<Text>().text = "Y O U  W I N";
		else if(_scores < _maxScore)
			_gameOver.GetComponentInChildren<Text>().text = "Y O U   L O S E R";

		//_gameOver.gameObject.SetActive(true);
	}

	private void OnDestroy()
	{
		_timer.OnTimeOut -= OnTimeOutHandler;
		_clickable.OnClick -= OnClickHandler;
	}

    private void OnClickHandler()
    {
		ChangeItemPosition();
		_scores++;
		_progressBar.GetComponent<Image>().fillAmount += 1f / _maxScore;
		_currentScoreText.text = _scores.ToString() + "/" + _maxScore.ToString();
		_clickSound.Play();
	}

    private void ChangeItemPosition()
	{
		float posX, posY;

		posX = Random.Range(_gameZone.bounds.min.x, _gameZone.bounds.max.x);
		posY = Random.Range(_gameZone.bounds.min.y, _gameZone.bounds.max.y);

		Vector2 newItemPosition = new Vector2(posX, posY);
		_clickable.SetPosition(newItemPosition);
	}

	private void DoubleScoreBonus()
	{
		Timer bonusTimer = new Timer();
		bonusTimer.Start(5f);
		_scores ++;
	}
}
