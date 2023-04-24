using System.Collections.Generic;
using Models;
using UI.ViewControllers;
using UnityEngine;

public class GraphCreator : MonoBehaviour
{
    [SerializeField] private SkillViewController _skillViewControllerPrefab;
    [SerializeField] private Transform _rootPosition;
    [SerializeField] private LineRenderer _lineRenderer;

    public void GenerateGraph(SkillModel[] skillModels)
    {
        foreach (var skillModel in skillModels)
        {
            var skillController = Instantiate(_skillViewControllerPrefab, _rootPosition);
            skillController.Initialize(skillModel);
            
            foreach (var nextSkillModel in skillModel.NextSkills)
            {
                DrawSkillsConnect(skillModel.Position, nextSkillModel.Position);
            }
        }
    }

    private void DrawSkillsConnect(Vector2 firstPosition, Vector2 secondPosition)
    {
        var lineRenderer = Instantiate(_lineRenderer, _rootPosition);
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(0, firstPosition);
        lineRenderer.SetPosition(1, secondPosition);
    }
}