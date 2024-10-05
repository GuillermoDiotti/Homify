using FluentAssertions;
using Homify.DataAccess.Contexts;
using Homify.DataAccess.Contexts.TestContext;
using Homify.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Homify.Tests.RepositoriesTests;

[TestClass]
public class RepositoryTests
{
    private readonly TestDbContext _context = HomifyDbContext.BuildTestDbContext();
    private readonly Repository<EntityTest> _repository;

    public RepositoryTests()
    {
        _repository = new Repository<EntityTest>(_context);
    }

    [TestInitialize]
    public void Setup()
    {
        _context.Database.EnsureCreated();
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context.Database.EnsureDeleted();
    }

    #region Add
    #region Success
    [TestMethod]
    public void Add_WhenInfoIsProvided_ShouldAddedToDatabase()
    {
        var entity = new EntityTest("some name");

        _repository.Add(entity);

        using var otherContext = HomifyDbContext.BuildTestDbContext();

        var entitiesSaved = otherContext.EntitiesTest.ToList();

        entitiesSaved.Count.Should().Be(1);

        var entitySaved = entitiesSaved[0];
        entitySaved.Id.Should().Be(entity.Id);
        entitySaved.Name.Should().Be(entity.Name);
    }
    #endregion
    #endregion

    #region GetAll
    [TestMethod]
    public void GetAll_WhenExistOnlyOne_ShouldReturnOne()
    {
        var expectedEntity = new EntityTest
        {
            Name = "dummy"
        };
        using var context = HomifyDbContext.BuildTestDbContext();
        context.Add(expectedEntity);
        context.SaveChanges();

        var entitiesSaved = _repository.GetAll();

        entitiesSaved.Count.Should().Be(1);

        var entitySaved = entitiesSaved[0];
        entitySaved.Id.Should().Be(expectedEntity.Id);
        entitySaved.Name.Should().Be(expectedEntity.Name);
    }
    #endregion

    #region Get
    [TestMethod]
    public void Get_WhenEntityExists_ShouldReturnEntity()
    {
        var entity = new EntityTest("existing entity");
        _context.Add(entity);
        _context.SaveChanges();

        var result = _repository.Get(e => e.Id == entity.Id);

        result.Should().NotBeNull();
        result.Id.Should().Be(entity.Id);
        result.Name.Should().Be(entity.Name);
    }

    [TestMethod]
    public void Get_WhenEntityDoesNotExist_ShouldThrowInvalidOperationException()
    {
        var nonExistentId = Guid.NewGuid().ToString();

        Action action = () => _repository.Get(e => e.Id == nonExistentId);

        action.Should().Throw<InvalidOperationException>()
            .WithMessage($"Entity {nameof(EntityTest)} not found");
    }

    #endregion

    #region Exist
    [TestMethod]
    public void Exist_WhenEntityExists_ShouldReturnTrue()
    {
        var entity = new EntityTest("existing entity");
        _context.Add(entity);
        _context.SaveChanges();

        var result = _repository.Exist(e => e.Name == "existing entity");

        result.Should().BeTrue();
    }

    [TestMethod]
    public void Exist_WhenEntityDoesNotExist_ShouldReturnFalse()
    {
        var result = _repository.Exist(e => e.Name == "non-existing entity");

        result.Should().BeFalse();
    }
    #endregion

    #region Remove
    [TestMethod]
    public void Remove_WhenEntityExists_ShouldRemoveEntity()
    {
        var entity = new EntityTest("entity to remove");
        _context.Add(entity);
        _context.SaveChanges();

        _repository.Remove(entity);

        _context.EntitiesTest.FirstOrDefault(e => e.Id == entity.Id).Should().BeNull();
    }

    [TestMethod]
    public void Remove_WhenEntityDoesNotExist_ShouldThrowException()
    {
        var entity = new EntityTest("non-existing entity");

        Action action = () => _repository.Remove(entity);

        action.Should().Throw<DbUpdateConcurrencyException>();
    }
    #endregion

    #region Update
    [TestMethod]
    public void Update_WhenEntityExists_ShouldUpdateEntity()
    {
        var entity = new EntityTest("old name");
        _context.Add(entity);
        _context.SaveChanges();

        _context.Entry(entity).State = EntityState.Detached;

        entity = new EntityTest
        {
            Id = entity.Id,
            Name = "new name"
        };
        _repository.Update(entity);

        var updatedEntity = _context.EntitiesTest.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id);
        updatedEntity.Should().NotBeNull();
        updatedEntity!.Name.Should().Be("new name");
    }

    [TestMethod]
    public void Update_WhenEntityDoesNotExist_ShouldThrowException()
    {
        var entity = new EntityTest
        {
            Id = Guid.NewGuid().ToString(),
            Name = "non-existing entity"
        };

        Action action = () => _repository.Update(entity);

        action.Should().Throw<DbUpdateConcurrencyException>();
    }
    #endregion
}
