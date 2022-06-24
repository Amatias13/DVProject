using TMPro;
using UnityEngine;

public class ResourcesTexts : MonoBehaviour
{
    [SerializeField] private GameObject diamondsText;
    [SerializeField] private GameObject powerText;
    [SerializeField] private GameObject waterText;
    [SerializeField] private GameObject resourcesText;
    [SerializeField] private GameObject foodText;
    [SerializeField] private GameObject peopleText;

    public void DiamondsText(int diamonds)
    {
        diamondsText.GetComponent<TextMeshProUGUI>().text = "" + diamonds;
    }

    public void PowerText(int power)
    {
        powerText.GetComponent<TextMeshProUGUI>().text = "" + power;
    }

    public void WaterText(int water)
    {
        waterText.GetComponent<TextMeshProUGUI>().text = "" + water;
    }

    public void ResourcesText(int resources)
    {
        resourcesText.GetComponent<TextMeshProUGUI>().text = "" + resources;
    }

    public void FoodText(int food)
    {
        foodText.GetComponent<TextMeshProUGUI>().text = "" + food;
    }

    public void PeopleText(int people)
    {
        peopleText.GetComponent<TextMeshProUGUI>().text = "" + people;
    }
}
