using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CraftingManager : MonoBehaviour
{
    private Item currentItem;
    public Image customCursor;

    public Slot[] craftingSlots;
    public List<Item> itemList;
    public string[] recipes;
    public Item[] recipeResult;
    public Slot resultSlot;

    //testing exit time
    private bool craftingComplete = false; // Flag to check if crafting is complete
    public float craftingDuration = 3f; // Duration for crafting completion
    private float craftingTimer = 0f;

    private void Update()
    {

        if (craftingComplete)
        {
            // If crafting is complete, start the timer
            craftingTimer += Time.deltaTime;

            if (craftingTimer >= craftingDuration)
            {
                // If the timer reaches the specified duration, load the next level
                LoadNextLevel();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if(currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);
                    if(dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;
                itemList[nearestSlot.index] = currentItem;

                currentItem = null;

                CheckForcreatedRecipes();
            }
        }
    }

    void CheckForcreatedRecipes()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach(Item  item in itemList)
        {
            if(item != null)
            {
                currentRecipeString += item.itemName;
            }
            else
            {
                currentRecipeString += "null";
            }
        }

        for(int i = 0; i< recipes.Length; i++)
        {
            if (recipes[i] == currentRecipeString) 
            {
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipeResult[i].GetComponent<Image>().sprite;
                resultSlot.item = recipeResult[i];

                craftingComplete = true; // Set craftingComplete flag to true when a recipe is created
                craftingTimer = 0f; // Reset the timer

                Debug.Log("Crafting complete! Flag set to true.");
            }
        }
    }


    public void OnClickSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForcreatedRecipes();
    }


    public void OnMouseDown(Item item)
    {
        if(currentItem == null)
        {
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }
    }


    void LoadNextLevel()
    {
        // Load the next level here
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Loading next level: " + SceneManager.GetSceneByBuildIndex(nextLevelIndex).name);
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.LogError("No next level available. Check Build Settings.");
        }
    }

}
