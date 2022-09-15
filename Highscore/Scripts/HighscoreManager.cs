using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace itfriedl.Highscores
{
    [Serializable]
    public struct ScoreModel
    {
        public string name;
        public int score;
        //public int time;
        //public int moves;
        public string date;
    }

    [Serializable]
    public class ScoreModelData
    {
        public List<ScoreModel> ScoreList = new List<ScoreModel>();
        public string version = Application.version;
    }

    public class HighscoreManager : MonoBehaviour
    {
        [SerializeField] private int maxScoreEntries = 25;

        public GameObject scorePrefab;
        public RectTransform Holder;
        private string localPathO => $"{Application.persistentDataPath}/highscore.json"; 

        void Start()
        {
        }


        public void AddHighscore(ScoreModel scoreModel, int mode)
        {
            ScoreModelData scoreModelData = new ScoreModelData();

            scoreModelData = GetSavedScores(mode);

            bool scoreAdded = false;

            for (int i = 0; i < scoreModelData.ScoreList.Count; i++)
            {
                if (Convert.ToInt32(scoreModel.score) > Convert.ToInt32(scoreModelData.ScoreList[i].score))
                {
                    scoreModelData.ScoreList.Insert(i, scoreModel);
                    scoreAdded = true;
                    break;
                }
            }

            if (!scoreAdded && scoreModelData.ScoreList.Count < maxScoreEntries)
            {
                scoreModelData.ScoreList.Add(scoreModel);
            }

            if (scoreModelData.ScoreList.Count > maxScoreEntries)
            {
                scoreModelData.ScoreList.RemoveRange(maxScoreEntries, scoreModelData.ScoreList.Count - maxScoreEntries);
            }

            SaveHighscores(scoreModelData, mode);
        }


     
        public void InsertScore(string name, int score, int moves = 0, int time = 0)
        {
            if (name.Length == 0)
            {
                name = "Player";
            }


            ScoreModel scoreModel = new ScoreModel();
            scoreModel.name = name;
            scoreModel.score = score;
            //scoreModel.time = time;
            //scoreModel.moves = moves;
            scoreModel.date = System.DateTime.Now.ToString("dd.MM.yyyy");

            //int mode = 0;
            //AddHighscore(scoreModel, mode); //local
            SaveScoreOnline(name, score); // online
        }

        public ScoreModelData GetSavedScores(int mode)
        {
            string strPath = localPathO;

            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
                ScoreModelData scoreModelData = new ScoreModelData();
                SaveHighscores(scoreModelData, mode);
            }

            using (StreamReader stream = new StreamReader(strPath))
            {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<ScoreModelData>(json);
            }
        }

        private void SaveHighscores(ScoreModelData scoreModelData, int mode)
        {
            string strPath = localPathO;

            using (StreamWriter stream = new StreamWriter(strPath))
            {
                string json = JsonUtility.ToJson(scoreModelData, true);

                stream.Write(json);
            }
        }

        public void DeleteAllScores(int mode)
        {
            ScoreModelData scoreModelData = new ScoreModelData();
            SaveHighscores(scoreModelData, mode);
            //ShowScores(GetSavedScores(mode));
            GetScoresOnline("http://gamerowmobile.com/highscore/highscoreout.php");
        }

        public void ShowScores(ScoreModelData smd, int wScore = 0, string wName = "") 
        {
            foreach (Transform child in Holder)
            {
                Destroy(child.gameObject);
            }

            float h = -10f;

            Debug.Log(smd.ScoreList.Count);

            Holder.sizeDelta = new Vector2(820f, (smd.ScoreList.Count * 130f) + 20f);
            for (int i = 0; i < smd.ScoreList.Count; i++)
            {
                Debug.Log(smd.ScoreList[i].name);
                GameObject tmpObject = Instantiate(scorePrefab, Holder);
                tmpObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f,h);
                h -= 130f;
                ScoreModel tmpScore = smd.ScoreList[i];
                tmpObject.GetComponent<HighscoreScript>().SetScore((i + 1).ToString(), tmpScore.score.ToString(), tmpScore.name);

                //if (wScore > 0)
                //{
                //    if (tmpScore.score == wScore && tmpScore.name == wName)
                //    {
                //        tmpObject.GetComponent<Image>().color = new Color32(255, 247, 153, 255);

                //    }
                //}
            }
        }

        public void clearUiScores()
        {
            foreach (Transform child in Holder)
            {
                Destroy(child.gameObject);
            }
        }

        public void SaveScoreOnline(string name, int score)
        {
            StartCoroutine(Upload(name, score));
        }

        IEnumerator Upload(string name, int score)
        {
            WWWForm form = new WWWForm();
            form.AddField("name", name);
            form.AddField("score", score);
            form.AddField("device", SystemInfo.deviceModel);

            using (UnityWebRequest www = UnityWebRequest.Post("http://gamerowmobile.com/highscore/highscorein.php", form))
            {
                yield return www.SendWebRequest();

                    Debug.Log("www Error " + www.error);
            }
        }

        public void GetScoresOnline(string url)
        {
            StartCoroutine(GetJsonRequest(url));
        }

        IEnumerator GetJsonRequest(string url)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            string str = request.downloadHandler.text;
            str = str.Replace("&quot;", "\"");
            str = str.Remove(str.Length - 3);
            str += "]}";

            ScoreModelData smd = JsonUtility.FromJson<ScoreModelData>(str);
            ShowScores(smd);
        }
    }
}
