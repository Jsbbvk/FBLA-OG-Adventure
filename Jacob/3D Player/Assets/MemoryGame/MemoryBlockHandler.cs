using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryBlockHandler : MonoBehaviour {

    public GameObject[] MemoryBlocks;
    public GameObject CurrBlock;
    public int currBlockIdx;

    public bool PlayRythm = false;
    public List<int> Indexes;

    public int Phase = 0;

    public bool Pause = false;

    public Button PlayRythmButton;

	void Start () {
        currBlockIdx = 0;
        Indexes = new List<int>();
    }
    private bool start = true;
	// Update is called once per frame
	void Update () {
        if (start)
        {
            //SelectCurrentBlock();
            start = false;
        }

        if (!Pause)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PrevBlock();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextBlock();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log(PlayRythm);
                SelectBlockChoice();
            }
        }
        if (PlayRythm)
        {
            PlayRythm = false;
            Debug.Log("Playing");
            Pause = true;
            DeselectCurrentBlock();
            
            StartCoroutine(PlayRythmPattern());
           
        }
        
    }

    IEnumerator PlayRythmPattern()
    {
        foreach (int i in Indexes)
        {
            MemoryBlocks[i].GetComponent<MemoryBlockObject>().Select();
            yield return new WaitForSeconds(0.5f);
            MemoryBlocks[i].GetComponent<MemoryBlockObject>().Deselect();
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(0.5f);
        Pause = false;
        SelectCurrentBlock();
    }

    public void SelectBlockChoice()
    {
        if (currBlockIdx == Indexes[Phase])
        {
            Phase++;
            MemoryBlocks[currBlockIdx].GetComponent<MemoryBlockObject>().Pressed();
            Debug.Log("Correct");
            if (Phase == Indexes.Count)
            {
                Pause = true;
                PlayRythmButton.interactable = true;
            }
        } else
        {
            Debug.Log("Err");
        }
    }

    public void PlayGame()
    {
        Indexes.Add(Random.Range(0, MemoryBlocks.Length));
        PlayRythm = true;
        Phase = 0;
    }


    public void DeselectCurrentBlock()
    {
        MemoryBlocks[currBlockIdx].GetComponent<MemoryBlockObject>().UserDeselect();
    }

    public void SelectCurrentBlock()
    {
        MemoryBlocks[currBlockIdx].GetComponent<MemoryBlockObject>().UserSelect();
    }

    public void NextBlock()
    {
        MemoryBlocks[currBlockIdx].GetComponent<MemoryBlockObject>().UserDeselect();
        currBlockIdx++;
        if (currBlockIdx >= MemoryBlocks.Length)
        {
            currBlockIdx = 0;
        }

        MemoryBlocks[currBlockIdx].GetComponent<MemoryBlockObject>().UserSelect();

    }

    public void PrevBlock()
    {
        MemoryBlocks[currBlockIdx].GetComponent<MemoryBlockObject>().UserDeselect();
        currBlockIdx--;
        if (currBlockIdx < 0)
        {
            currBlockIdx = MemoryBlocks.Length-1;
        }

        MemoryBlocks[currBlockIdx].GetComponent<MemoryBlockObject>().UserSelect();

    }
}
