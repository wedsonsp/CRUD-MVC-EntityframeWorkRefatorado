using System.Net;
using CadastroContatosEntityFrameworkRefat.Repositorio;
using System.Web.Mvc;
using CadastroContatosEntityFrameworkRefat.Entities;

namespace CadastroContatosEntityFramework.Controllers
{
    public class ContatoController : Controller
    {
        //Objeto criado automaticamente.
        private readonly ContatoRepository _contatoRepository;

        public ContatoController()
        {
            _contatoRepository = new ContatoRepository();
        }

        //Abaixo foram criadas todas as Actions Results.
        // GET: Contato
        public ActionResult Index()
        {
            //Substitui pelos novos métodos do Repositório.
            //return View(db.Contato.ToList());
            return View(_contatoRepository.ObterTodos());
        }

        // GET: Contato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = _contatoRepository.ObterPorId(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,Email")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                //db.Contato.Add(contato);
                _contatoRepository.Salvar(contato);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = _contatoRepository.ObterPorId(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,Email")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contato).State = EntityState.Modified;
                //db.SaveChanges();
                _contatoRepository.Atualizar(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contato contato = db.Contato.Find(id);
            Contato contato = _contatoRepository.ObterPorId(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Contato contato = db.Contato.Find(id);
            //db.Contato.Remove(contato);
            //db.SaveChanges();
            _contatoRepository.Remover(id);
            return RedirectToAction("Index");
        }

        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */
    }
}
