using UnityEngine;
using UnityEngine.EventSystems;
using  UnityEngine.UI;
using Random = System.Random;

public class Clicker : MonoBehaviour
{
	[SerializeField]
	private Text _maxScoreText;
	[SerializeField]
	private Text _currentScoreText;
	[SerializeField]
	private GameObject _gamePanel;
	[SerializeField]
	private GameObject _progressBar;
	private int _scores = 0;
	private RectTransform _itemTransform;
	private SpriteRenderer _gameZone;
	private int _maxScore = 20;



	private void Awake()
	{
		_itemTransform = GetComponent<RectTransform>();
		_gameZone = _gamePanel.GetComponent<SpriteRenderer>();
		_progressBar.GetComponent<Image>().fillAmount = 0;
		_maxScoreText.text = "Max score " + _maxScore.ToString();
		_currentScoreText.text = _scores.ToString() + "/" + _maxScore.ToString();
		ChangeItemPosition();

	}

	public void OnClick ()
	{
		ChangeItemPosition();
		_scores ++;
		_progressBar.GetComponent<Image>().fillAmount += 1f/_maxScore;
		_currentScoreText.text = _scores.ToString() + "/" + _maxScore.ToString();
	}

	private void ChangeItemPosition()
	{
		float posX, posY;
		Random random = new Random();

		posX = random.Next((int)_gameZone.bounds.min.x,(int)_gameZone.bounds.max.x);
		posY = random.Next((int) _gameZone.bounds.min.y, (int) _gameZone.bounds.max.y);

		Vector2 newItemPosition = new Vector2(posX, posY);
		_itemTransform.transform.position = newItemPosition;

	}

	private void DoubleScoreBonus()
	{


	}
}
