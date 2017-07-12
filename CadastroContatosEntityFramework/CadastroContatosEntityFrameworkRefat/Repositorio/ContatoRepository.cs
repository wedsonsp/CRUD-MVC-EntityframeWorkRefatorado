using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CadastroContatosEntityFrameworkRefat.Context;
using CadastroContatosEntityFrameworkRefat.Entities;

namespace CadastroContatosEntityFrameworkRefat.Repositorio
{
    public class ContatoRepository
    {
        //Dependência
        private readonly ContatoMVCContext _context;

        public ContatoRepository()
        {
            _context = new ContatoMVCContext();
        }

        public void Salvar(Contato contato)
        {
            _context.Contato.Add(contato);
            _context.SaveChanges();
        }

        public List<Contato> ObterTodos()
        {
            return _context.Contato.ToList();
        }

        public void Atualizar(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            //Remove o contato localizado no banco.
            var contato = ObterPorId(id);
            _context.Contato.Remove(contato);
            //Salva as alterações
            _context.SaveChanges();
        }

        public Contato ObterPorId(int? id)
        {
           return _context.Contato.Find(id);
        }
    }
}
