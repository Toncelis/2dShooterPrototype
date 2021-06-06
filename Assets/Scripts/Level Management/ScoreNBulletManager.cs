using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreNBulletManager : MonoBehaviour
{
    [SerializeField] private Settings.SO_Settings_Balance settings;

    private static ScoreNBulletManager _instance;
    public static ScoreNBulletManager GetInstance ()
    {
        return _instance;
    }
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        reloadsPerSale = settings.ReloadsPerSale;
        saleCost = settings.ReloadsCost;
        score = 0;
        reloads = settings.ReloadsOnStart;
        salePeriod = settings.SalesPeriod;
        UpdateAmmo();
        UpdateScore();
        RejectProposal();
    }

    private int reloadsPerSale;
    private int saleCost;

    private int score;
    public int Score => score;

    private int reloads;

    [SerializeField] UnityEngine.UI.Text scoreText;
    [SerializeField] UnityEngine.UI.Text ammoText;

    private void UpdateScore ()
    {
        scoreText.text = $"{score}";
    }

    private void UpdateAmmo()
    {
        ammoText.text = $"{reloads}";
    }

    public void RaiseScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void BuyClip ()
    {
        score -= saleCost;
        reloads += reloadsPerSale;

        UpdateAmmo();
        UpdateScore();

        RejectProposal();
    }


    public bool Reload ()
    {
        if (reloads > 0)
        {
            reloads -= 1;
            UpdateAmmo();
            return true;
        }
        return false;
    }


    [SerializeField] GameObject saleProposalPanel;
    float salePeriod;

    public void TryMakeProposal ()
    {
        if (score >= saleCost)
        {
            saleProposalPanel.SetActive(true);
        }
        else
        {
            Invoke("TryMakeProposal", salePeriod);
        }
    }

    public void RejectProposal ()
    {
        saleProposalPanel.SetActive(false);
        Invoke("TryMakeProposal", salePeriod);
    }

    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (saleProposalPanel.activeSelf)
            {
                RejectProposal();
            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (saleProposalPanel.activeSelf)
            {
                BuyClip();
            }
        }
    }

    public void TurnOff()
    {
        this.enabled = false;
    }
}
