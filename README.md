
# Modelling Group Dynamics and Predator Response in Meerkat Colonies

*A collective animal behaviour project: simulating how meerkat groups coordinate movement and react to predators.*



---

## 📖 Project Description

Meerkats live in cohesive groups where individuals take turns acting as sentinels, emit specific call types that signal predation risk, and use vocal "moving calls" to decide when the group moves on. Existing computational work on social animal behaviour (including meerkat data) models movement and interaction structure, but **there is no existing computer-science simulation of how meerkat groups behave in the presence of predators**.

In this project we plan to build such a model. We will ground it in published biological research on meerkat sentinel behaviour and alarm calls, and use it to simulate group dynamics and predator response. If time allows, we will also investigate whether quorum-based movement decisions can be recovered from observational data and used as a mechanistic prior for the model.

---

## 👥 Team

| Name | GitHub account |
|------|----------------|
| _Simona Cholakova_ | [@simona-cholakova](https://github.com/simona-cholakova) |
| _Filip Trajkoski_ | [@FT1E](https://github.com/FT1E) |


---

## 📚 Starting Point

Our work builds on the following papers:

Here are the three papers as clickable links, each pointing to its DOI:

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

## 🎯 Our Plan

### Main extension

- 🐾 Model **meerkat behaviour in the presence of predators**
- 🖥️ Fill the gap: **no existing CS simulation** covers this
- 🔬 Use **biological research** to inform and parameterise the model

### 🌟 Stretch goals (if time permits)

**Quorum and movement** (Bousquet et al. + Gendron et al.)

- **Causal discovery of quorum:** Can causal discovery recover the quorum effect from observational data? For instance, do the links "number of simultaneous movers → next-step movement" show a threshold-like (sigmoidal) dependence?
- **Quorum threshold vs. group size:** Does the quorum threshold scale with group size? Bousquet's groups ranged from 6 to 19 individuals, so a model could test whether the threshold *T* stays near 2–3 or grows with *N*, which they flag as an open question.
- **Mechanistic rule vs. black box:** Is a mechanistic quorum rule (a sigmoid with parameters *T* and *β*) a better generative model of group speed changes than a black-box GNN or LSTM? Gendron et al. found their models match accuracy but produce unrealistic simulated sequences, so a rule-informed prior might help.

---

## 📈 Progress Log

_This section will be updated regularly during the course._

| Date | Update |
|------|--------|
| _22.10.2026_ | Repository created |

