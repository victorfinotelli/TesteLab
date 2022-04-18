using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteLab.Models;

namespace TesteLab
{
    public class JogosController : Controller
    {
        private JogosContext db = new JogosContext();

        // GET: Jogos
        public ActionResult Index()
        {
            return View(db.Jogos.ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            /*Mensagem de sucesso ao criar*/
            ViewBag.Sucess = TempData["Sucess"] as bool?;
            return View();
        }

        // POST: Jogos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Data,Pontos")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogos);
                db.SaveChanges();
                /*Mensagem de sucesso ao criar*/
                TempData["Sucess"] = true;
                return RedirectToAction("Create"); //Coloquei create no lugar do index para teste ---------------------------------------------------
            }

            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Pontos")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogos jogos = db.Jogos.Find(id);
            if (jogos == null)
            {
                return HttpNotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogos jogos = db.Jogos.Find(id);
            db.Jogos.Remove(jogos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*Buscando resultados(Logicas)*/
        public ActionResult Resultados()
        {
            var resultados = new Resultados();
            /*Como primeira pontuação não conta como record ele inicia no -1 o contador*/
            var recorde2 = -1;
            var comparacao = 0;

            /*Alimentando o array com a coluna Pontos*/
            var pontuacao = db.Jogos.Select(c => c.Pontos).ToList();

            foreach(int i in pontuacao)
            {
                if(comparacao < i)
                {
                    comparacao= i;
                    recorde2 += 1;
                }

            }
            
            /*Buscando informações do banco*/
            resultados.JogosRealizados = db.Jogos.Count();
            resultados.TotalPontos = db.Jogos.Sum(c => c.Pontos);
            resultados.MediaPontos = db.Jogos.Average(c => c.Pontos);
            resultados.MaiorPontuacao = db.Jogos.Max(c => c.Pontos);
            resultados.MenorPontuacao = db.Jogos.Min(c => c.Pontos);
            resultados.Recordes = recorde2;
            resultados.DataJogoMin = db.Jogos.Min(c => c.Data);
            resultados.DataJogoMax = db.Jogos.Max(c => c.Data);
            return View(resultados);
            

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}
