
# Modelling Group Dynamics and Predator Response in Meerkat Colonies

---

## Project Description

Meerkats live in cohesive groups where sentinels take turns watching for predators, distinct call types signal different levels of risk, and moving calls determine when the group sets off. Existing computational work on social animals models movement and interaction structure, but to our knowledge no simulation combines sentinel rotation, referential alarm calls and quorum-based movement.

This project builds such a simulation, grounded in published meerkat research. We focus on how groups coordinate collective movement, examining how quorum effects emerge from data, how they depend on group size, and whether a simple rule-based model can outperform complex learned models as a generator of realistic group behaviour.

---

## Team

| Name | GitHub account |
|------|----------------|
| _Simona Cholakova_ | [@simona-cholakova](https://github.com/simona-cholakova) |
| _Filip Trajkoski_ | [@FT1E](https://github.com/FT1E) |


---

## Starting Point

Our work builds on the following papers:

1. [**Discrete call types referring to predation risk enhance the efficiency of the meerkat sentinel system**](https://doi.org/10.1038/srep44436)
   Rauber & Manser, *Scientific Reports*, 2017. DOI: 10.1038/srep44436

2. [**Behaviour Modelling of Social Animals via Causal Structure Discovery and Graph Neural Networks**](https://doi.org/10.48550/arXiv.2312.14333)
   Gendron et al., arXiv preprint, 2023. DOI: 10.48550/arXiv.2312.14333

3. [**Moving calls: a vocal mechanism underlying quorum decisions in cohesive groups**](https://doi.org/10.1098/rspb.2010.1739)
   Bousquet, Sumpter & Manser, *Proceedings of the Royal Society B*, 2011. DOI: 10.1098/rspb.2010.1739

### What these papers are about

| # | Paper | Summary |
|---|-------|---------|
| 1 | Discrete call types referring to predation risk… | _Summary: how meerkat sentinels use distinct call types to signal predation risk and how this improves the sentinel system's efficiency._ |
| 2 | Behaviour Modelling of Social Animals via Causal Structure Discovery and GNNs | _Summary: uses causal structure discovery and graph neural networks to model interactions and behaviour in social animal groups._ |
| 3 | Moving calls: a vocal mechanism underlying quorum decisions… | _Summary: how moving calls drive quorum decisions about when a cohesive group starts moving._ |

---

## Our Plan

### Research questions

**Quorum and movement** (Bousquet et al. + Gendron et al.)
- **Causal discovery of quorum:** Can causal discovery learn the quorum effect from observational data? That is, will the model Gendron et al. also display the quorum effect observed in the research of Bousquet et al.
- **Quorum threshold vs. group size:** Does the quorum threshold scale with group size? Bousquet's groups ranged from 6 to 19 individuals, so a model could test whether the threshold *T* stays near 2–3 or grows with *N*, which they flag as an open question.
- **Simple rule vs. Complex AI:** Is a simple quorum rule (a sigmoid with parameters *T* and *β*) a better generative model of group speed changes than a complex AI like GNN or LSTM? Gendron et al. found their models match accuracy but produce unrealistic simulated sequences seen from statistical point of view, so a model enforced with certain rules might help.


---

## Progress Log


| Date | Update |
|------|--------|
| _22.10.2026_ | Repository created |

