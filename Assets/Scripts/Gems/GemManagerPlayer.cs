using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Esto va en el Player
// Se asignan los 

public class GemManagerPlayer : MonoBehaviour
{
    public CharacterController controller;
    
    // Gem Coding:
    // 0 - Emerald
    // 1 - Diamond
    // 2 - Ruby
    // 3 - Saphire

    public List<TextMeshProUGUI> textGems;
    public List<int> goalGems;
    public List<int> numGems;

    public bool goalAchieved = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numGems.Count; i++)
        {
            numGems[i] = 0;
            textGems[i].text = "" + numGems[i].ToString() + "/" + goalGems[i].ToString();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        EnergyRock rock = hit.gameObject.GetComponent<EnergyRock>();

        if (rock != null)
        {

            numGems[rock.colorCode] += 1;

            if (numGems[rock.colorCode] > goalGems[rock.colorCode])
            {
                numGems[rock.colorCode] = goalGems[rock.colorCode];
            }
            textGems[rock.colorCode].text = "" + numGems[rock.colorCode].ToString() + "/" + goalGems[rock.colorCode].ToString();
            hit.gameObject.SetActive(false);

            Debug.Log("Gem " + rock.colorCode.ToString() + " + 1. New Total: " + numGems[rock.colorCode]);

            checkRocks();

            
        }
    }

    private bool checkRocks()
    {
        for (int i = 0; i < numGems.Count; i++)
        {
            if (numGems[i] < goalGems[i])
            {
                return false;
            }
            else
            {
                Debug.Log("Gem " + i + " Goal Achieved ");
            }
        }

        Debug.Log("All Gems Achieved");
        goalAchieved = true;
        return true;
    }
}
