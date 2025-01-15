using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class CardLoader : MonoBehaviour, IGameLoader
{
    public GameObject CardPrefabe;
    public Transform CardContainer;

    [Tooltip("Цвет при отсутствии оценки")]
    public Color NoneColor = Color.white;
    [Tooltip("Цвет отметки при оценке: grade < 50 && grade > 0")]
    public Color BadGradeColor = Color.white;
    [Tooltip("Цвет отметки при оценке: grade < 80 && grade > 50")]
    public Color GoodGradeColor = Color.white;
    [Tooltip("Цвет отметки при оценке: grade > 80")]
    public Color SuperGradeColor = Color.white;

    private CardInformation cardInfo;


    void IGameLoader.Load()
    {
        CardLoad();
    }

    public void CardLoad()
    {
        string query = $"Select ID, name, description, grade, image from Scenario;";

        SqlConnect.OpenConnection();
        SqliteDataReader reader = SqlConnect.ExecuteReader(query);
        int i = 0;

        if (reader.HasRows)
        {
            int grade = 0;

            while (reader.Read())
            {
                grade = 0;
                if (!reader.IsDBNull(3)) grade = reader.GetInt32(3);

                NewCard(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    grade
                    );
                i++;
            }
        }

        SqlConnect.CloseConnection();

        ResizeContainer(i);
        

    }

    private void NewCard(int id, string textContent, int grade)
    {
        GameObject card = Instantiate(CardPrefabe);
        card.transform.SetParent(CardContainer);
        
        cardInfo = card.GetComponent<CardInformation>();


        SetValues(id, textContent, grade.ToString());
        SetColor(grade);
    }

    private void SetValues(int id, string name, string grade)
    {
        cardInfo.ScenarioID = id;
        cardInfo.TextName.text = name;
        cardInfo.TextGrade.text = grade + "%";
    }


    private void SetColor(int grade)
    {
        Button button = cardInfo.button;

        ColorBlock colorBlock = button.colors;
        colorBlock = GradeToColor(colorBlock, grade);

        button.colors = colorBlock;
    }

    private ColorBlock GradeToColor(ColorBlock colorBlock, int grade)
    {
        if (grade > 80) colorBlock.normalColor = SuperGradeColor;
        else if (grade < 80 && grade > 50) colorBlock.normalColor = GoodGradeColor;
        else if (grade < 50 && grade > 0) colorBlock.normalColor = BadGradeColor;
        else colorBlock.normalColor = NoneColor;

        return colorBlock;
    }

    private void ResizeContainer(int colElements)
    {
        colElements = colElements / 4;
        RectTransform rectTransform = CardContainer.GetComponent<RectTransform>();
        Vector2 size = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
        size.y = colElements * 350 + colElements * 20 + 350 * 3 - 40;

        rectTransform.sizeDelta = size;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -size.y / 2);
    }

}
