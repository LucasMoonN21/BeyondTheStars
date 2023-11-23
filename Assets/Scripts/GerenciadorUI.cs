using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Jobs;

public class GerenciadorUI : MonoBehaviour
{
    public Sprite[] vidas;

    public Image mostrarImagemDasVidas;
    public void AtualizaVidas( int vidasAtuais )
    {
        mostrarImagemDasVidas.sprite = vidas[vidasAtuais];

    }

    public void AtualizaPlacar()
    {




    }

}