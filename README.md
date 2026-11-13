# Modelling Group Dynamics and Predator Response in Meerkat Colonies

* * *

## Project Description

Meerkats live in cohesive groups where sentinels take turns watching for predators, distinct call types signal different levels of risk, and moving calls determine when the group sets off. While foraging, meerkats also give soft close calls, and local differences in how often individuals call create a group-level pattern that helps keep the moving group together. Existing computational work on social animals models movement and interaction structure, but to our knowledge no simulation combines close-call cohesion, sentinel rotation, referential alarm calls and quorum-based movement.

This project builds such a simulation as an agent-based model in Unity (2D). Each meerkat is an autonomous agent driven by a state machine (idle, foraging, moving, running, recruiting, mobbing) and communicates through six discrete call types: close, moving, foraging, run, recruit and recruit-mob calls. The simulation is grounded in published meerkat research. Our main focus is how close-call rules keep a foraging group cohesive, and how the group follows "vocal hotspots", areas where many close calls are heard.

* * *

## Team

| Name               | GitHub account                                           |
|--------------------|----------------------------------------------------------|
| *Simona Cholakova* | [@simona-cholakova](https://github.com/simona-cholakova) |
| *Filip Trajkoski*  | [@FT1E](https://github.com/FT1E)                         |

* * *

## Starting Point

Our work builds on the following papers:

1. [**Collective close calling mediates group cohesion in foraging meerkats via spatially determined differences in call rates**](https://doi.org/10.1016/j.anbehav.2021.12.014) Engesser & Manser, *Animal Behaviour*, 2022. DOI: 10.1016/j.anbehav.2021.12.014
2. [**Group cohesion in foraging meerkats: follow the moving 'vocal hot spot'**](https://doi.org/10.1098/rsos.170004) Gall & Manser, *Royal Society Open Science*, 2017. DOI: 10.1098/rsos.170004
3. [**Moving calls: a vocal mechanism underlying quorum decisions in cohesive groups**](https://doi.org/10.1098/rspb.2010.1739) Bousquet, Sumpter & Manser, *Proceedings of the Royal Society B*, 2011. DOI: 10.1098/rspb.2010.1739
4. [**Discrete call types referring to predation risk enhance the efficiency of the meerkat sentinel system**](https://doi.org/10.1038/srep44436) Rauber & Manser, *Scientific Reports*, 2017. DOI: 10.1038/srep44436
5. [**Behaviour Modelling of Social Animals via Causal Structure Discovery and Graph Neural Networks**](https://doi.org/10.48550/arXiv.2312.14333) Gendron et al., arXiv preprint, 2023. DOI: 10.48550/arXiv.2312.14333

### What these papers are about

| # | Paper                                                                         | Summary                                                                                                                                                                                                              |
|---|-------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1 | Collective close calling mediates group cohesion in foraging meerkats…        | *Summary: how foraging meerkats adjust their close call rates according to their proximity to groupmates, so that local differences in call rates create "vocal hotspots" that attract and may guide group movement.* |
| 2 | Group cohesion in foraging meerkats: follow the moving 'vocal hot spot'       | *Summary: a playback experiment showing that meerkats use the changing pattern of close calls in the group to adjust their movement direction and keep the group together.*                                          |
| 3 | Moving calls: a vocal mechanism underlying quorum decisions…                  | *Summary: how moving calls drive quorum decisions about when a cohesive group starts moving.*                                                                                                                        |
| 4 | Discrete call types referring to predation risk…                              | *Summary: how meerkat sentinels use distinct call types to signal predation risk and how this improves the sentinel system's efficiency.*                                                                            |
| 5 | Behaviour Modelling of Social Animals via Causal Structure Discovery and GNNs | *Summary: uses causal structure discovery and graph neural networks to model interactions and behaviour in social animal groups.*                                                                                    |

* * *

## Our Plan

### Research questions

**Cohesion through close calls** (Engesser & Manser, Gall & Manser)

- **Cohesion from local rules:** Can simple local rules, in which each meerkat's close call rate depends on the proximity of its groupmates, keep a simulated foraging group cohesive?
- **Following vocal hotspots:** Does the simulated group follow areas with a high density of close calls, as real meerkats do? For example, does it split when two artificial hotspots are placed at its front and back edges?

**Extensions** (Bousquet et al., Rauber & Manser, Gendron et al.)

- **Quorum and group size:** Does a quorum rule (a sigmoid with parameters *T* and *β*) based on moving calls reproduce group departure, and does the quorum threshold scale with group size? Bousquet's groups ranged from 6 to 19 individuals.
- **Predator response:** Do referential alarm calls that distinguish levels of risk make the group's response to predators more efficient than a single undifferentiated alarm?
- **Simple rules vs. learned models:** Is a rule derived directly from the biology a better generative model of group behaviour than a learned model such as a GNN? Gendron et al. found their models match accuracy but produce unrealistic simulated sequences from a statistical point of view.

* * *

## Milestones

Report deadlines are tracked as GitHub milestones. Each milestone groups the issues needed to deliver that report.

| Milestone                     | Deadline               | Deliverables                                                                                                                                                                                                                          | Status         |
|-------------------------------|------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------|
| Report 1                      | 13 November 2026       | Review of concepts and existing models, general overview of the problem, proposed approach. 4 pages max.                                                                                                                              | ⬜ In progress |
| Report 2                      | 11 December 2026       | Polished Report 1 based on feedback, detailed methods, proposed verification methodology. Author contributions in Acknowledgements. 4 pages max.                                                                                       | ⬜ Not started |
| Final report and presentation | Friday, 8 January 2027 | Final polished report (max 6 pages, max 3000 words, with GitHub link and author contributions), 5 min presentation slides, 3 min narrated video (mp4, 1280x720@30fps, with running simulation), polished README with run instructions. | ⬜ Not started |

* * *

## Progress Log

| Date         | Update                                                                                              |
|--------------|-----------------------------------------------------------------------------------------------------|
| *22.10.2026* | Repository created                                                                                  |
| *13.11.2026* | Topic revised: agent-based Unity simulation of meerkat colonies, focusing on close-call cohesion    |
