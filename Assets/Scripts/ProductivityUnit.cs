using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    public ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void BuildingInRange()
    {
        Debug.Log("BUildinRange");  //함수호출이안되네?
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
